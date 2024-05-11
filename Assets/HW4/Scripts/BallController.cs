using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StageManager.OnGameStart += OnGameStart;
            StageManager.OnGameRestart += ResetPosition;
            StageManager.OnGameReset += ResetPosition;
        }

        private void OnDestroy()
        {
            StageManager.OnGameStart -= OnGameStart;
            StageManager.OnGameRestart -= ResetPosition;
            StageManager.OnGameReset -= ResetPosition;
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
        private void ResetPosition()
        {
            transform.position = _startingPosition;
            _rb.velocity = Vector2.zero;
        }
    }
}