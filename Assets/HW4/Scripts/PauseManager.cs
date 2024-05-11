using System;
using UnityEngine;

namespace Arkanoid
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _pauseButton;
        [SerializeField]
        private string _pauseWindowName;

        private void Start()
        {
            ContinueButton.OnContinueButtonClick += Unpause;
            ExitButton.OnExitButtonClick += Unpause;
        }

        private void OnDestroy()
        {
            ContinueButton.OnContinueButtonClick -= Unpause;
            ExitButton.OnExitButtonClick -= Unpause;
        }

        private void Update()
        {
            if(Input.GetKeyDown(_pauseButton))
            {
                UISystem.Instance.UIGame.OpenWindow(_pauseWindowName);
                Time.timeScale = 0;
            }
        }

        private void Unpause()
        {
            Time.timeScale = 1;
            UISystem.Instance.UIGame.CloseWindow(_pauseWindowName);
        }
    }
}