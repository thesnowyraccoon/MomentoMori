using UnityEngine;
using UnityEngine.SceneManagement;

//Title: Make Your MAIN MENU Quickly! | Unity UI Tutorial For Beginners
//Author: Rehope Games 
//Date: April 21 2025
//Platform: Youtube
//Code version: Unknown
//Availability: https://youtu.be/DX7HyN7oJjE?si=s2ex07i9EnO4aECp

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("World");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
