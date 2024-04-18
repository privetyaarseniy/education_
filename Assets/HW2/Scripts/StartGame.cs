using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject textCloud;
    [SerializeField]
    private GameObject thinkMenu;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        startMenu.SetActive(false);
        textCloud.SetActive(true);
        thinkMenu.SetActive(true);

        Debug.Log("Preview started");
    }
}
