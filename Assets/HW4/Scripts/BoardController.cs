using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private Vector3 MousePosition { get; set; }
    private void Update()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        transform.position = new Vector3(MousePosition.x, transform.position.y, transform.position.z);
    }
}
