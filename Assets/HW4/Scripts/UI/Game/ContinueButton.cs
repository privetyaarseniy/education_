using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    [RequireComponent(typeof(ButtonVisuals))]
    public class ContinueButton : MonoBehaviour
    {
        public static event Action OnContinueButtonClick;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Invoke);
        }

        private void Invoke()
        {
            Debug.Log("Continue clicked");
            OnContinueButtonClick?.Invoke();
        }
    }
}