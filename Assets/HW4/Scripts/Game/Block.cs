using System;
using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        public static event Action<int> OnBlockDestroy;

        [SerializeField]
        private bool indestructible;
        [SerializeField]
        private BonusType pickupBonusType;
        [SerializeField]
        private int scoreGiven;
        [SerializeField]
        private Color[] hitColors;

        private int _hitsToDestroy;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (indestructible)
            {
                enabled = false;
            }
            _hitsToDestroy = hitColors.Length;
            ChangeColor();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallController ballController))
            {
                _hitsToDestroy--;
                if (_hitsToDestroy <= 0)
                {
                    OnBlockDestroy?.Invoke(scoreGiven);
                    gameObject.SetActive(false);

                    if(pickupBonusType != BonusType.None)
                    {
                        var bonus = BonusSpawner.Instance.Pool.Get();
                        bonus.SetBonus(pickupBonusType);
                        bonus.gameObject.transform.position = gameObject.transform.position;
                    }
                }
                else
                {
                    ChangeColor();
                }
            }
        }

        private void ChangeColor()
        {
            _spriteRenderer.color = hitColors[_hitsToDestroy - 1];
        }
    }
}
