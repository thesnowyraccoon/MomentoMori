using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public float sceneTimer = 30f;

    GameObject player;
    GameObject UI;
    GameObject playerCamera;

    void Start()
    {
        if (gameObject.scene.isLoaded)
        {
            player = GameObject.Find("playerRemy");
            Destroy(player);

            UI = GameObject.Find("UI");
            Destroy(UI);

            playerCamera = GameObject.Find("PlayerCamera");
            Destroy(playerCamera);

            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(sceneTimer);

        Debug.Log("Game Closed");

        Application.Quit();
    }
}
