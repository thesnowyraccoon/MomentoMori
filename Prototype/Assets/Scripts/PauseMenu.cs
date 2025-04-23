using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//Title: Make Your MAIN MENU Quickly! | Unity UI Tutorial For Beginners
//Author: Rehope Games 
//Date: April 21 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/DX7HyN7oJjE?si=s2ex07i9EnO4aECp

public class PauseMenu : MonoBehaviour
{
    public InputAction pauseAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.IsPressed())
        {
            SceneManager.LoadScene("Pause Menu");
        }
    }
}
