using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class UIBase : MonoBehaviour
{
    protected WindowBase[] Windows { get; set; }
    public UIBase Instance { get; private set; }
    


    protected void Awake()
    {
        Instance = this;
        Windows = GetComponentsInChildren<WindowBase>();
    }

    public void OpenWindow(int windowNumber)
    {
        var windowToOpen = Windows.First(x => x.number == windowNumber);

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
