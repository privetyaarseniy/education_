using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class StageManager : MonoBehaviour
    {
        public static event Action OnGameStart;
        public static event Action OnBallLaunched;
        public static event Action OnGameReset;
        public static event Action OnGameRestart;

        [SerializeField]
        private KeyCode _pauseButton;
        [SerializeField]
        private string _pauseWindowName;
        [SerializeField]
        private string _startWindow;
        [SerializeField]
        private string _gameWindow;
        [SerializeField]
        private string _restartWindow;

        private void Start()
        {
            ExitButton.OnExitButtonClick += Reset;
            ContinueButton.OnContinueButtonClick += OnContinueButtonPressed;
            BallManager.OnLastBallMissed += OnLastBallMissed;
        }

        private void OnDestroy()
        {
            ExitButton.OnExitButtonClick -= Reset;
            ContinueButton.OnContinueButtonClick -= OnContinueButtonPressed;
            BallManager.OnLastBallMissed -= OnLastBallMissed;
        }

        private void Update()
        {
            if (PauseSystem.Instance.IsPaused && Input.GetKeyDown(KeyCode.LeftShift))
            {
                OnGameStart();
                UISystem.Instance.UIGame.OpenWindow(_gameWindow);
                PauseSystem.Instance.SwitchPause();
            }

            if (!PauseSystem.Instance.IsPaused && Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnBallLaunched();
            }
            if(!PauseSystem.Instance.IsPaused && Input.GetKeyDown(_pauseButton))
            {
                UISystem.Instance.UIGame.OpenWindow(_pauseWindowName);
                PauseSystem.Instance.SwitchPause();
            }
        }

        private void Reset()
        {
            OnGameRestart();
            UISystem.Instance.UIGame.OpenWindow(_startWindow);
        }

        private void OnContinueButtonPressed()
        {
            UISystem.Instance.UIGame.CloseWindow(_pauseWindowName);
            PauseSystem.Instance.SwitchPause();
        }

        private void OnLastBallMissed()
        {
            PauseSystem.Instance.SwitchPause();
            if (LivesSystem.Instance.CurrentLives <= 1)
            {
                OnGameRestart();
                LivesSystem.Instance.ResetLives();
                UISystem.Instance.UIGame.OpenWindow(_restartWindow);
            }
            else
            {
                OnGameReset();
                LivesSystem.Instance.EditLives(-1);
                UISystem.Instance.UIGame.OpenWindow(_startWindow);
            }
        }
    }
}
