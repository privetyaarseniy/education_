using HW4;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HW4
{
    public class ScoreManager : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        private int scoreCount;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            Block.OnBlockDestroy += EditScore;
        }

        private void OnDestroy()
        {
            Block.OnBlockDestroy -= EditScore;
        }

        private void EditScore(int score)
        {
            scoreCount += score;
            scoreText.text = $"Score: {scoreCount}";
        }
    }
}