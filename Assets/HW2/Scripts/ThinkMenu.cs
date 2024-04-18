using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class ThinkMenu : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private GameObject thinkMenu;
    [SerializeField]
    private GameObject gameMenu;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        thinkMenu.SetActive(false);
        gameMenu.SetActive(true);

        Debug.Log("Game started");
    }
}