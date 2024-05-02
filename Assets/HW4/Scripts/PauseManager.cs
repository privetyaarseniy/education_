using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField]
        private string _pauseWindowName;
        [SerializeField]
        private string _backToMenuWindowName;

        private UISystem _gameUI;
        private UISwitcher _switcher;

        private void Start()
        {
            _gameUI = GameObject.Find("GameUI").GetComponent<UISystem>();
            _switcher = GameObject.Find("UISwitcher").GetComponent<UISwitcher>();

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
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                _gameUI.Instance.OpenWindow(_pauseWindowName);
            }
        }

        private void Unpause()
        {
            _gameUI.CloseWindow(_pauseWindowName);
            Time.timeScale = 1;
        }
    }
}