using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreTextEditor : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();

            _text.text = "SCORE: 0";
        }

        private void OnEnable()
        {
            ScoreManager.OnScoreChange += OnScoreChange;
        }

        private void OnDestroy()
        {
            ScoreManager.OnScoreChange -= OnScoreChange;
        }

        private void OnScoreChange(int value)
        {
            _text.text = $"SCORE: {value}";
        }
    }
}