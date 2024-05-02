using Arkanoid;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class ScoreManager : MonoBehaviour
    {
        public static event Action<int> OnScoreChange;

        private int scoreCount;

        private void Start()
        {
            StartManager.OnGameRestart += OnGameRestart;
            Block.OnBlockDestroy += EditScore;
        }

        private void OnDestroy()
        {
            Block.OnBlockDestroy -= EditScore;
        }

        private void EditScore(int scoreToAdd)
        {
            scoreCount += scoreToAdd;
            OnScoreChange(scoreCount);
        }

        private void OnGameRestart()
        {
            EditScore(-scoreCount);
        }
    }
}