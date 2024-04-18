using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UISystem : MonoBehaviour
{
    public UISystem Instance { get; private set; }
    [SerializeField]
    private WindowBase[] _windows;
    [SerializeField]
    private WindowType _startWindow;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _windows = GetComponentsInChildren<WindowBase>();

        foreach (WindowBase win in _windows)
        {
            if (win.Type != _startWindow)
            {
                win.gameObject.SetActive(false);
            }
        }
    }

    public void OpenWindow(WindowType window)
    {
        var windowToOpen = _windows.First(x => x.Type == window);

        if (windowToOpen == null)
        {
            return;
        }

        if (!windowToOpen.IsPopup)
        {
            foreach (WindowBase win in _windows)
            {
                win.gameObject.SetActive(false);
            }
        }

        windowToOpen.gameObject.SetActive(true);
    }
}
