using Arkanoid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public static event Action<string> OnLevelButtonClick;

    [SerializeField]
    private int _levelNum;
    [SerializeField]
    private string _levelName;
    

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Invoke);
        GetComponentInChildren<TextMeshProUGUI>().text = $"{_levelNum}";
    }

    private void Invoke()
    {
        OnLevelButtonClick(_levelName);
    }
}
