using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private bool _indestructible;
        [SerializeField]
        private int _scoreGiven;
        [SerializeField]
        [Range(1f, 3f)]
        private int _hitsToDestroy;
        [SerializeField]
        private Color _1HitLeft;
        [SerializeField]
        private Color _2HitLeft;
        [SerializeField]
        private Color _3HitLeft;

        private SpriteRenderer _spriteRenderer;
        private GameObject _ball;

        public static event Action<int> OnBlockDestroy;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _ball = GameObject.FindGameObjectWithTag("Ball");

            if (_indestructible)
            {
                enabled = false;
            }
            ChangeColor();
        }

        private void Update()
        {
            if (_hitsToDestroy <= 0)
            {
                OnBlockDestroy(_scoreGiven);
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == _ball)
            {
                _hitsToDestroy--;
                ChangeColor();
            }
        }

        private void ChangeColor()
        {
            switch(_hitsToDestroy)
            {
                case 1: _spriteRenderer.color = _1HitLeft; break;
                case 2: _spriteRenderer.color = _2HitLeft; break;
                case 3: _spriteRenderer.color = _3HitLeft; break;
            }
        }
    }
}
