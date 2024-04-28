using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HW4
{
    public class MenuUI : UIBase
    {
        private new void Awake()
        {
            base.Awake();
            OpenWindow(0);
        }
    }
}