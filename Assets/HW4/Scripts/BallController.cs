using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
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

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartManager.OnGameStart += OnGameStart;
            StartManager.OnGameRestart += OnGameRestart;
        }

        private void OnDestroy()
        {
            StartManager.OnGameStart -= OnGameStart;
            StartManager.OnGameRestart -= OnGameRestart;
        }

        private void FixedUpdate()
        {
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _speedLimit);
        }

        private void OnGameStart()
        {
            transform.position = _startingPosition;
            _rb.AddForce(new Vector2(Random.Range(-_xRangeStartForce, _xRangeStartForce + 1), _yStartForce), ForceMode2D.Impulse);
        }
        private void OnGameRestart()
        {
            transform.position = _startingPosition;
            _rb.velocity = Vector2.zero;
        }
    }
}