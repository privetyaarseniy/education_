using System;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class LivesSystem : MonoBehaviour
    {
        public static LivesSystem Instance { get; private set; }
        public static event Action<int> OnLivesChange;
        public int CurrentLives { get => _currentLives; }

        [SerializeField]
        private int _startingLives;

        private int _currentLives;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            EditLives(_startingLives);
        }

        public void EditLives(int amountToAdd)
        {
            _currentLives += amountToAdd;
            OnLivesChange?.Invoke(CurrentLives);
        }

        public void ResetLives()
        {
            EditLives(_startingLives - 1);
        }
    }
}
