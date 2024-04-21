using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
{
    public class EdgeCollider : MonoBehaviour
    {
        private EdgeCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<EdgeCollider2D>();
        }

        private void Start()
        {
            EdgeColliderInit();
        }

        private void EdgeColliderInit()
        {
            var edges = new List<Vector2>
            {
                Camera.main.ScreenToWorldPoint(Vector2.zero),
                Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)),
                Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)),
                Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)),
                Camera.main.ScreenToWorldPoint(Vector2.zero)
            };

            _collider.SetPoints(edges);
        }
    }
}