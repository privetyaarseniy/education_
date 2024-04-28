using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public abstract class WindowBase : MonoBehaviour
{

    public abstract string Name { get; }
    public abstract bool IsPopup { get; }

}
