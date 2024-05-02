using Arkanoid;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string _gameSceneName;
    [SerializeField]
    private string _backToMenuWindowName;

    private UISystem _gameUI;
    private UISystem _menuUI;
    private UISwitcher _switcher;
    private string _currentLevel;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _gameUI = GameObject.Find("GameUI").GetComponent<UISystem>();
        _menuUI = GameObject.Find("MenuUI").GetComponent<UISystem>();
        _switcher =GameObject.Find("UISwitcher").GetComponent<UISwitcher>();

        LevelButton.OnLevelButtonClick += StartLevel;
        ExitButton.OnExitButtonClick += Exit;
    }

    private void OnDestroy()
    {
        LevelButton.OnLevelButtonClick -= StartLevel;
        ExitButton.OnExitButtonClick -= Exit;
    }

    private void StartLevel(string levelSceneName)
    {
        SceneManager.LoadSceneAsync(levelSceneName, LoadSceneMode.Additive);
        _currentLevel = levelSceneName;
        SceneManager.LoadSceneAsync(_gameSceneName, LoadSceneMode.Additive);
        _switcher.Switch();
    }

    private void Exit()
    {
        _menuUI.OpenWindow(_backToMenuWindowName);
        SceneManager.UnloadSceneAsync(_gameSceneName);
        SceneManager.UnloadSceneAsync(_currentLevel);
        _switcher.Switch();
    }
}
