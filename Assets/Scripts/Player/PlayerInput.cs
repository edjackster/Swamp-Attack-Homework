using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    
    public event Action MouseClicked;
    public event Action UpPressed;
    public event Action DownPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            MouseClicked?.Invoke();
        
        if(Input.GetKeyDown(KeyCode.W))
            UpPressed?.Invoke();
        
        if(Input.GetKeyDown(KeyCode.S))
            DownPressed?.Invoke();
    }
}
