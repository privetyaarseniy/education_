using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW4
{
    public class StartManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ball;

        public static event Action OnGameStart;
        public static event Action OnGameRestart;
        public static event Action OnGameReset;

        private bool isGameActive { get; set; }

        private void Awake()
        {
            isGameActive = false;    
        }

        private void Update()
        {
            if(!isGameActive && Input.GetKeyDown(KeyCode.Space))
            {
                OnGameStart();
                isGameActive = true;
            }
            if(isGameActive && _ball.transform.position.y < -16)
            {
                OnGameRestart();
                isGameActive = false;
            }
        }
    }
}