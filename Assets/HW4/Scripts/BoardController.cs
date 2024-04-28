using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _startingPosition;
        private bool _isActive = false;

        private Camera _camera;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _camera = Camera.main;

            StartManager.OnGameStart += OnGameLaunch;
            StartManager.OnGameRestart += OnGameRestart;
        }

        private void OnDestroy()
        {
            StartManager.OnGameStart -= OnGameLaunch;
            StartManager.OnGameRestart -= OnGameRestart;
        }

        private void Update()
        {

            if (_isActive)
            {
                var leftLimit = _camera.ScreenToWorldPoint(new Vector2(0, 0)).x + _spriteRenderer.size.x * transform.localScale.x / 2;
                var rightLimit = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - _spriteRenderer.size.x * transform.localScale.x / 2;
                var x = _camera.ScreenToWorldPoint(Input.mousePosition).x;
                x = Mathf.Clamp(x, leftLimit, rightLimit);
                transform.position = new Vector2(x, transform.position.y);
            }

        }

        private void OnGameLaunch()
        {
            transform.position = _startingPosition;
            _isActive = true;
        }

        private void OnGameRestart()
        {
            _isActive = false;
            transform.position = _startingPosition;
        }
    }
}
