using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour
{
    [SerializeField]
    private int _window;
    [SerializeField]
    private UIBase UI;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Open);
    }

    private void Open()
    {
        UI.Instance.OpenWindow(_window);
    }

}