using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public float sceneTimer = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartSequence());
    }
    
    IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(sceneTimer);

        Debug.Log("Menu Scene");

        SceneManager.LoadScene("Menu");
    }
}
