using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Arkanoid
{
    public class BallController : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _startingPosition;
        [SerializeField]
        private int _speedLimit;
        [SerializeField]
        private int _yStartForce;
        [SerializeField]
        private int _xRangeStartForce;


        private Rigidbody2D _rb;
        private ObjectPool<BallController> _pool;

        public void SetPool(ObjectPool<BallController> pool)
        {
            _pool = pool;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(gameObject.transform.position.y <= -16)
            {
                _pool.Release(GetComponent<BallController>());
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _speedLimit);
        }
    }
}