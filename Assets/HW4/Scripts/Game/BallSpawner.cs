using UnityEngine;
using UnityEngine.Pool;

namespace Arkanoid
{
    public class BallSpawner : MonoBehaviour
    { 
        public ObjectPool<BallController> Pool { get; private set; }

        [SerializeField]
        private BallController ballPrefab;

        private void Awake()
        {
            Pool = new ObjectPool<BallController>(CreateBall, OnGetBall, OnReleaseBall, OnDestroyBall, true, 5, 100);
        }

        private BallController CreateBall()
        {
            var ball = Instantiate(ballPrefab, gameObject.transform);
            ball.SetPool(Pool);
            return ball;
        }

        private void OnGetBall(BallController ball)
        {
            ball.gameObject.SetActive(true);
        }

        private void OnReleaseBall(BallController ball)
        {
            ball.gameObject.SetActive(false);
        }

        private void OnDestroyBall(BallController ball)
        {
            Destroy(ball.gameObject);
        }
    }
}