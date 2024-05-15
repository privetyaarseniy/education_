using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Arkanoid
{
    [RequireComponent(typeof(BonusBehaviour), typeof(Rigidbody2D))]
    public class BonusBehaviour : MonoBehaviour
    {
        public static event Action<BonusType> OnBonusPick;

        [SerializeField]
        private int startForceMultiplier;

        private BonusType _bonusType;
        private ObjectPool<BonusBehaviour> _pool;

        private void OnEnable()
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * startForceMultiplier, ForceMode2D.Impulse);
        }

        private void Update()
        {
            if(gameObject.transform.position.y <= -16)
            {
                _pool.Release(GetComponent<BonusBehaviour>());
            }
        }

        public void SetPool(ObjectPool<BonusBehaviour> pool)
        {
            _pool = pool;
        }

        public void SetBonus(BonusType bonusType)
        {
            _bonusType = bonusType;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BoardController controller))
            {
                OnBonusPick?.Invoke(_bonusType);
                _pool.Release(GetComponent<BonusBehaviour>());
            }
        }
    }
}