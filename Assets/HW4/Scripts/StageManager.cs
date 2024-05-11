using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class StageManager : MonoBehaviour
    {
        public static event Action OnGameStart;
        public static event Action OnGameRestart;
        public static event Action OnGameReset;

        [SerializeField]
        private GameObject _ball;
        [SerializeField]
        private string _startWindow;
        [SerializeField]
        private string _gameWindow;
        [SerializeField]
        private string _restartWindow;

        private LivesManager _livesManager;
        private bool _isGameActive;

        private void Awake()
        {
            _isGameActive = false;

            _livesManager = gameObject.GetComponent<LivesManager>();
        }

        private void Start()
        {
            ExitButton.OnExitButtonClick += Reset;
        }

        private void OnDestroy()
        {
            ExitButton.OnExitButtonClick -= Reset;
        }

        private void Update()
        {
            if(!_isGameActive && Input.GetKeyDown(KeyCode.LeftShift))
            {
                OnGameStart();
                UISystem.Instance.UIGame.OpenWindow(_gameWindow);
                _isGameActive = true;
            }
            if(_isGameActive && _ball.transform.position.y < -16)
            {
                _isGameActive = false;
                if (_livesManager.CurrentLives <= 1)
                {
                    OnGameRestart();
                    UISystem.Instance.UIGame.OpenWindow(_restartWindow);
                }
                else
                {
                    OnGameReset();
                    UISystem.Instance.UIGame.OpenWindow(_startWindow);
                }
            }
        }

        private void Reset()
        {
            OnGameRestart();
            UISystem.Instance.UIGame.OpenWindow(_startWindow);
        }
    }
}
