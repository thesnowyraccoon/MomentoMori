using System.Collections;
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
    [SerializeField] Animator transitionAnim;
    [SerializeField] Animator carnivalAnim;
    [SerializeField] Animator hospitalAnim;
    [SerializeField] Animator homeAnim;

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

        StartCoroutine(LoadLevel());
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(ResetRemy(sceneName));  //Go to the desired scene using the scene name
    }

    // Title: Unity Scene Transitions: Creating an Immersive and seamless Gaming Experience
    // Author: Rehope Games
    // Date: 7 April 2023
    // Code version: Unknown
    // Availability: https://youtu.be/HBEStd96UzI?si=ffU8jJTDLNc6oTgo

    IEnumerator LoadLevel()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "BossFight 1")
        {
            if (carnivalAnim != null)
            {
                carnivalAnim.SetTrigger("End");
            }
        }
        else if (currentScene.name == "BossFightt 2")
        {
            if (hospitalAnim != null)
            {
                hospitalAnim.SetTrigger("End");
            }
        }
        else if (currentScene.name == "BossFight 3")
        {
            if (homeAnim != null)
            {
                homeAnim.SetTrigger("End");
            }
        }
        else
        {
            if (transitionAnim != null)
            {
                transitionAnim.SetTrigger("End");
            }
        }

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);

        Debug.Log("Scene Loaded");

        if (currentScene.name == "BossFight 1")
        {
            if (carnivalAnim != null)
            {
                carnivalAnim.SetTrigger("Start");
            }
        }
        else if (currentScene.name == "BossFightt 2")
        {
            if (hospitalAnim != null)
            {
                hospitalAnim.SetTrigger("Start");
            }
        }
        else if (currentScene.name == "BossFight 3")
        {
            if (homeAnim != null)
            {
                homeAnim.SetTrigger("Start");
            }
        }
        else
        {
            if (transitionAnim != null)
            {
                transitionAnim.SetTrigger("Start");
            }
        }
    }

    IEnumerator ResetRemy(string scene)
    {
        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("End");
        }

        yield return new WaitForSeconds(3);

        SceneManager.LoadSceneAsync(scene);

        Debug.Log("Scene Loaded");

        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("Start");
        }
    }            
}

