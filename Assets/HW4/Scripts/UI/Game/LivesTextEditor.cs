using Arkanoid;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LivesTextEditor : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();

            _text.text = "LIVES: 0";
        }

        private void OnEnable()
        {
            LivesSystem.OnLivesChange += OnLivesChange;
        }

        private void OnDestroy()
        {
            LivesSystem.OnLivesChange -= OnLivesChange;
        }

        private void OnLivesChange(int value)
        {
            _text.text = $"LIVES: {value}";
        }
    }
}