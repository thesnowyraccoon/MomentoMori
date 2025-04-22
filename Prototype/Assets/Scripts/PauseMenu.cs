using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
