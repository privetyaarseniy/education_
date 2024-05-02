using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class UISwitcher : MonoBehaviour
    {
        public UISwitcher Instance { get; private set; }

        [SerializeField]
        private Canvas _gameUI;
        [SerializeField]
        private Canvas _menuUI;

        private void Awake()
        {
            Instance = this;
        }

        public void Switch()
        {
            (_gameUI.sortingOrder, _menuUI.sortingOrder) = (_menuUI.sortingOrder, _gameUI.sortingOrder);
        }
    }
}