using System;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class LivesManager : MonoBehaviour
    {
        public static event Action<int> OnLivesChange;
        public int CurrentLives { get => _currentLives; }

        [SerializeField]
        private int _startingLives;

        private int _currentLives;

        private void Start()
        {
            EditLives(_startingLives);

            StartManager.OnGameReset += OnGameReset;
        }

        private void EditLives(int amountToAdd)
        {
            _currentLives += amountToAdd;
            OnLivesChange?.Invoke(CurrentLives);
        }

        private void OnGameReset()
        {
            EditLives(-1);
        }
    }
}
