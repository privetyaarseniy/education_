using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
{
    public class StartManager : MonoBehaviour
    {
        public static event Action OnGameStart;
        public static event Action OnGameRestart;
        public static event Action OnGameReset;

        [SerializeField]
        private GameObject _ball;        
        [SerializeField]
        private string _gameWindow;
        [SerializeField]
        private string _restartWindow;

        private UISystem UI;

        private bool isGameActive { get; set; }

        private void Awake()
        {
            isGameActive = false;    
        }

        private void Start()
        {
            UI = GameObject.Find("GameUI").GetComponent<UISystem>();
        }

        private void Update()
        {
            if(!isGameActive && Input.GetKeyDown(KeyCode.Space))
            {
                OnGameStart();
                UI.Instance.OpenWindow(_gameWindow);
                isGameActive = true;
            }
            if(isGameActive && _ball.transform.position.y < -16)
            {
                OnGameRestart();
                UI.Instance.OpenWindow(_restartWindow);
                isGameActive = false;
            }
        }
    }
}
