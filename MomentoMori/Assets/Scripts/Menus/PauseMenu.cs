using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Canvas pause;

    bool isOpen = false;

    GameObject player;
    GameObject UI;
    GameObject playerCamera;

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
        Time.timeScale = 1f; // Start game time
    }

    public void MainMenu()
    {
        player = GameObject.Find("playerRemy");
        Destroy(player);

        UI = GameObject.Find("UI");
        Destroy(UI);

        playerCamera = GameObject.Find("PlayerCamera");
        Destroy(playerCamera);
    
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
