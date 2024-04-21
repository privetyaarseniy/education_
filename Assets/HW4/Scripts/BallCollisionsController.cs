using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
{
    public class BallCollisionsController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _leftCollider;
        [SerializeField]
        private GameObject _rightCollider;
        [SerializeField]
        private int _xForce;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == _leftCollider)
            {
                _rb.AddForce(new Vector2(-_xForce, 0), ForceMode2D.Impulse);
            }
            else if (collision.gameObject == _rightCollider)
            {
                _rb.AddForce(new Vector2(_xForce, 0), ForceMode2D.Impulse);
            }
        }
    }
}
