using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        _input.enabled = false;
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        _input.enabled = true;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
