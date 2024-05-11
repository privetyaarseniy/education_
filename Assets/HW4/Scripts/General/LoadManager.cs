using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class LoadManager : MonoBehaviour
    {
        [SerializeField]
        private string _gameSceneName;

        private string _levelSceneName;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            LevelButton.OnLevelButtonClick += LoadToGame;
            ExitButton.OnExitButtonClick += LoadToMenu;
            StageManager.OnGameRestart += OnGameRestart;
        }

        private void OnDisable()
        {
            LevelButton.OnLevelButtonClick -= LoadToGame;
            ExitButton.OnExitButtonClick -= LoadToMenu;
            StageManager.OnGameRestart -= OnGameRestart;
        }

        private void LoadToGame(string levelSceneName)
        {
            _levelSceneName = levelSceneName;

            SceneManager.LoadScene(_gameSceneName, LoadSceneMode.Additive);
            SceneManager.LoadScene(_levelSceneName, LoadSceneMode.Additive);
            UISystem.Instance.Switch();
        }

        private void LoadToMenu()
        {
            SceneManager.UnloadSceneAsync(_gameSceneName);
            SceneManager.UnloadSceneAsync(_levelSceneName);
            UISystem.Instance.Switch();
        }

        private void OnGameRestart()
        {
            SceneManager.UnloadSceneAsync(_levelSceneName);
            SceneManager.LoadScene(_levelSceneName, LoadSceneMode.Additive);
        }
    }
}