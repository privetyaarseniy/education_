using System;
using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private bool _indestructible;
        [SerializeField]
        private int _scoreGiven;
        [SerializeField]
        private Color[] _hitColors;
        private int _hitsToDestroy;

        private SpriteRenderer _spriteRenderer;
        private GameObject _ball;

        public static event Action<int> OnBlockDestroy;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_indestructible)
            {
                enabled = false;
            }
            _hitsToDestroy = _hitColors.Length;
            ChangeColor();
        }

        private void Start()
        {
            _ball = GameObject.Find("Ball");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == _ball)
            {
                _hitsToDestroy--;
                if (_hitsToDestroy <= 0)
                {
                    OnBlockDestroy?.Invoke(_scoreGiven);
                    gameObject.SetActive(false);
                }
                else
                {
                    ChangeColor();
                }
            }
        }

        private void ChangeColor()
        {
            _spriteRenderer.color = _hitColors[_hitsToDestroy - 1];
        }
    }
}
