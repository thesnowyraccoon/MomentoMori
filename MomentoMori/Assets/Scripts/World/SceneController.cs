using UnityEngine;
using UnityEngine.SceneManagement;

// Title: Unity 2D SCENE MANAGEMENT tutorial
 // Author: Rehope Games
 // Date: 13 March 2023
 // Code version: Unknown
 // Availability: https://youtu.be/E25JWfeCFPA?si=jPe9A3gVatkBPRZE

public class SceneController : MonoBehaviour
{
    public static SceneController instance; //Access from anywhere
                                            //Script Destroyer
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Doesnt destroy the empty object containg the script
        }
        else
        {
            Destroy(gameObject); //If scene already has this object it will destroy the previous one
        }
    }
    public void NextLevel()
    { //Load Next Scene. (+1 is to indicate the scene after it)
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);  //Go to the desired scene using the scene name
    }
}

