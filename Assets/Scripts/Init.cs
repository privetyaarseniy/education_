using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject textCloud;
    [SerializeField]
    private GameObject thinkMenu;
    [SerializeField]
    private GameObject gameMenu;
    [SerializeField]
    private GameObject settingsMenu;

    private void Awake()
    {
        startMenu.SetActive(true);
        textCloud.SetActive(false);
        thinkMenu.SetActive(false);
        gameMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Debug.Log("Initialized");
    }
}
