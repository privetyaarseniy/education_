using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public abstract class WindowBase : MonoBehaviour
{

    public abstract WindowType Type { get; }
    public abstract bool IsPopup { get; }

}
