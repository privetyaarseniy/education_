using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class OpenWindow : MonoBehaviour
    {
        [SerializeField]
        private string _windowName;

        private UIController UI;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Open);
            UI = GetComponentInParent<UIController>();
        }

        private void Open()
        {
            UI.OpenWindow(_windowName);
        }
    }
}