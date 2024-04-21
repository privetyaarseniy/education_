using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace HW4
{
    public class UIStartManager : UIBase
    {
        [SerializeField]
        private int _startWindow;
        [SerializeField]
        private int _gameWindow;
        [SerializeField]
        private int _restartWindow;

        private void Awake()
        {
            base.Awake();
            OpenWindow(_startWindow);
        }
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

        private void OnGameLaunch()
        {
            OpenWindow(_gameWindow);
        }

        private void OnGameRestart()
        {
            OpenWindow(_restartWindow);
        }
    }
}