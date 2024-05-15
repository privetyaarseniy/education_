using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class EdgeCollider : MonoBehaviour
    {
        private EdgeCollider2D _collider;
        private Camera _camera;

        private void Awake()
        {
            _collider = GetComponent<EdgeCollider2D>();
        }

        private void Start()
        {
            _camera = Camera.main;
            EdgeColliderInit();
            
        }

        private void EdgeColliderInit()
        {
            var edges = new List<Vector2>
            {
                _camera.ScreenToWorldPoint(Vector2.zero),
                _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)),
                _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)),
                _camera.ScreenToWorldPoint(new Vector2(0, Screen.height)),
                _camera.ScreenToWorldPoint(Vector2.zero)
            };

            _collider.SetPoints(edges);
        }
    }
}