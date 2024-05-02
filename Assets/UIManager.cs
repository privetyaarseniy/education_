using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class UIManager : MonoBehaviour
    {
        public UIManager Instance { get; private set; }
        public GameObject GameUI { get => _gameUI; }
        public GameObject MenuUI { get => _menuUI; }

        [SerializeField]
        private GameObject _gameUI;
        [SerializeField]
        private GameObject _menuUI;

        private void Awake()
        {
            Instance = this;
        }
    }
}