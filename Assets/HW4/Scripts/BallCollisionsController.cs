using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BallCollisionsController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _board;
        [SerializeField]
        private int _xForce;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == _board)
            {
                if(_board.transform.position.x > gameObject.transform.position.x)
                {
                    _rb.AddForce(new Vector2(-_xForce, 0), ForceMode2D.Impulse);
                }
                else
                {
                    _rb.AddForce(new Vector2(_xForce, 0), ForceMode2D.Impulse);
                }
            }
        }
    }
}
