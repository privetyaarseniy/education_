using Arkanoid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Arkanoid
{
    public class BallManager : MonoBehaviour
    {
        public static event Action OnLastBallMissed;

        [SerializeField]
        private BoardController board;
        [SerializeField]
        private int xRangeStartForce;
        [SerializeField]
        private int yStartForce;

        private BallSpawner _spawner;
        private BallController _initialBall;

        private void Awake()
        {
            StageManager.OnBallLaunched += OnBallLaunched;

            _spawner = gameObject.GetComponent<BallSpawner>();
        }

        private void Start()
        {
            _initialBall = _spawner.Pool.Get();
            _initialBall.transform.SetParent(board.transform, true);
            _initialBall.transform.localPosition = new Vector2(0, 2);
        }

        private void OnDestroy()
        {
            StageManager.OnBallLaunched -= OnBallLaunched;
        }

        private void Update()
        {
            if (_spawner.Pool.CountActive < 1)
            {
                OnLastBallMissed?.Invoke();
            }
        }

        private void OnBallLaunched()
        {
            _initialBall.transform.SetParent(null);
            _initialBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-xRangeStartForce, xRangeStartForce + 1), yStartForce), ForceMode2D.Impulse);
        }
    }
}