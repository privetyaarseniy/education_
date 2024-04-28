using HW4;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private KeyCode _quitKey;
    [SerializeField]
    private UISystem _menuUI;
    [SerializeField]
    private UISystem _gameUI;
    [SerializeField]
    private string _backToMenuWindow;

    private bool IsInGame { get; set; }
    private int CurrentLevel { get; set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _gameUI = GameObject.Find("GameUI").GetComponent<UISystem>();
        _menuUI = GameObject.Find("MenuUI").GetComponent<UISystem>();

        LevelButton.OnLevelButtonClick += StartLevel;
        StartManager.OnGameRestart += OnGameRestart;

        _gameUI.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        LevelButton.OnLevelButtonClick -= StartLevel;
        

    }

    void Update()
    {
        if (IsInGame && Input.GetKeyDown(_quitKey))
        {
            SceneManager.UnloadSceneAsync((int)HW4.Scenes.Game);
            SceneManager.UnloadSceneAsync(CurrentLevel);
            _gameUI.gameObject.SetActive(false);

            _menuUI.gameObject.SetActive(true);
            _menuUI.Instance.OpenWindow(_backToMenuWindow);

            IsInGame = false;
            
        }
    }

    private void StartLevel(int levelNum)
    {
        SceneManager.LoadSceneAsync((int)HW4.Scenes.Game, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(levelNum, LoadSceneMode.Additive);
        CurrentLevel = levelNum;
        _gameUI.gameObject.SetActive(true);

        _menuUI.gameObject.SetActive(false);

        IsInGame = true;
    }

    private void OnGameRestart()
    {
        SceneManager.UnloadSceneAsync(CurrentLevel);
        SceneManager.LoadSceneAsync(CurrentLevel, LoadSceneMode.Additive);
    }
}
