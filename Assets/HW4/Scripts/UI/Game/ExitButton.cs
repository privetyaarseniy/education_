using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    [RequireComponent(typeof(ButtonVisuals))]
    public class ExitButton : MonoBehaviour
    {
        public static event Action OnExitButtonClick;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Invoke);
        }

        private void Invoke()
        {
            Debug.Log("Exit clicked");
            OnExitButtonClick?.Invoke();
        }
    }
}