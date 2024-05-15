using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class PauseSystem : MonoBehaviour
    {
        public static PauseSystem Instance { get; private set; }
        public bool IsPaused { get; private set; }

        private void Awake()
        {
            Instance = this;

            Time.timeScale = 0;
            IsPaused = true;
        }

        public void SwitchPause()
        {
            if (IsPaused)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            IsPaused = !IsPaused;
        }
    }
}