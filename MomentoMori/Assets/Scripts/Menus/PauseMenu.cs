using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Canvas pause;

    bool isOpen = false;

    void Start()
    {
        pause = GetComponent<Canvas>();
    }

    public void Open()
    {
        if (isOpen == false)
        {
            pause.enabled = true;    
            isOpen = true;
        }
        else
        {
            pause.enabled = false;
            isOpen = false;
        }
    } 

    public void Resume()
    {
        pause.enabled = false;
        isOpen = false;
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
