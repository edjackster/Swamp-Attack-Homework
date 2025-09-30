using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UIService _uiService;  // обязательно в инспекторе
    
    private const int LeftMouseButton = 0;
    
    public event Action MouseClicked;
    public event Action UpPressed;
    public event Action DownPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton) && !_uiService.IsPointerOverUI())
            MouseClicked?.Invoke();
        
        if(Input.GetKeyDown(KeyCode.W))
            UpPressed?.Invoke();
        
        if(Input.GetKeyDown(KeyCode.S))
            DownPressed?.Invoke();
    }
}
