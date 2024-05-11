using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        public static event Action<string> OnLevelButtonClick;
        public string SceneName { get; private set; }

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(InvokeEvent);
        }

        public void Setup(string sceneName, int levelIndex)
        {
            SceneName = sceneName;
            GetComponentInChildren<TextMeshProUGUI>().text = levelIndex.ToString();
        }

        private void InvokeEvent()
        {
            OnLevelButtonClick?.Invoke(SceneName);
        }
    }
}