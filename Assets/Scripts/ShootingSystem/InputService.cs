using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public bool IsReload { get; private set; }

    public bool IsFirePressed { get; private set; }

    private void Update()
    {
        IsFirePressed = Input.GetMouseButtonDown(0);
        IsReload = Input.GetKeyDown(KeyCode.R);
    }



}
