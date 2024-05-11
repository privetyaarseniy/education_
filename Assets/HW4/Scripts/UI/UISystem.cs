using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class UISystem : MonoBehaviour
    {
        public static UISystem Instance { get; private set; }
        public UIController UIGame { get => _UIGame; }
        public UIController UIMenu { get => _UIMenu; }

        [SerializeField]
        private UIController _UIGame;
        [SerializeField]
        private UIController _UIMenu;

        private void Awake()
        {
            Instance = this;

            UIGame.gameObject.SetActive(false);
            UIMenu.gameObject.SetActive(true);
        }

        public void Switch()
        {
            UIGame.gameObject.SetActive(!UIGame.gameObject.activeSelf);
            UIMenu.gameObject.SetActive(!UIMenu.gameObject.activeSelf);
        }

    }
}