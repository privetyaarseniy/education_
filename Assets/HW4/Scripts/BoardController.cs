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

        private void Start()
        {
            StartManager.OnGameLaunch += OnGameLaunch;
            StartManager.OnGameRestart += OnGameRestart;
        }

        private void OnDestroy()
        {
            StartManager.OnGameLaunch -= OnGameLaunch;
            StartManager.OnGameRestart -= OnGameRestart;
        }

        private void Update()
        {
            
            if(_isActive)
            {
                transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
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
