using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private GameObject settingsMenu;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Open);
        closeButton.GetComponent<Button>().onClick.AddListener(Close);
        exitButton.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }

    private void Open()
    {
        settingsMenu.SetActive(true);

        Debug.Log("Settings opened");
    }

    private void Close()
    {
        settingsMenu.SetActive(false);

        Debug.Log("Settings closed");
    }
}
