using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace HW4
{
    public class LivesManager : MonoBehaviour
    {
        public int CurrentLives { get => _currentLives; }

        [SerializeField]
        private int _startingLives;

        private int _currentLives;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = $"LIVES: {_startingLives}";

            _currentLives = _startingLives;
        }

        private void Start()
        {
            StartManager.OnGameReset += OnGameReset;
        }

        private void EditLives(int amountToAdd)
        {
            _currentLives += amountToAdd;
            _text.text = $"LIVES: {_currentLives}";
        }

        private void OnGameReset()
        {
            EditLives(-1);
        }
    }
}
