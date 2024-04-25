using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private int _levelNum;
    [SerializeField]
    private HW4.Scenes _level;

    public static event Action<int> OnLevelButtonClick;


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Invoke);

        GetComponentInChildren<TextMeshProUGUI>().text = $"{_levelNum}";
    }

    private void Invoke()
    {
        Debug.Log("LevelButton clicked");
        OnLevelButtonClick((int)_level);
    }
}
