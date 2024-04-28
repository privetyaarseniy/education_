using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

namespace HW4
{
    public class GameUI : UIBase
    {
        [SerializeField]
        private int _startWindow;
        [SerializeField]
        private int _gameWindow;
        [SerializeField]
        private int _restartWindow;

        private new void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            OpenWindow(_startWindow);
        }

        private void Start()
        {
            StartManager.OnGameStart += OnGameStart;
            StartManager.OnGameRestart += OnGameRestart;
        }

        private void OnDestroy()
        {
            StartManager.OnGameStart -= OnGameStart;
            StartManager.OnGameRestart -= OnGameRestart;
        }

        private void OnGameStart()
        {
            OpenWindow(_gameWindow);
        }

        private void OnGameRestart()
        {
            OpenWindow(_restartWindow);
        }
    }
}