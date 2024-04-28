using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UISystem : MonoBehaviour
{
    [SerializeField]
    private string _startWindow;

    private WindowBase[] Windows { get; set; }
    public UISystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Windows = GetComponentsInChildren<WindowBase>();
        OpenWindow(_startWindow);
    }

    public void OpenWindow(string windowName)
    {
        var windowToOpen = Windows.First(x => x.Name == windowName);

        if (windowToOpen == null)
        {
            return;
        }

        if (!windowToOpen.IsPopup)
        {
            foreach (WindowBase win in Windows)
            {
                win.gameObject.SetActive(false);
            }
        }

        windowToOpen.gameObject.SetActive(true);
    }
}
