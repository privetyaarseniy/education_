using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour
{
    [SerializeField]
    private WindowType _window;
    [SerializeField]
    private UISystem UI;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Open);
    }

    private void Open()
    {
        UI.Instance.OpenWindow(_window);
    }

}
