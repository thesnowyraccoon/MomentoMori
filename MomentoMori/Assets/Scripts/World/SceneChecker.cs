using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    CinemachineConfiner2D playerCamera;
    PolygonCollider2D cameraBounds;

    void Start()
    {
        SetCamera();
        TarotCheck();
    }

    void SetCamera()
    {
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<CinemachineConfiner2D>();
        cameraBounds = GameObject.Find("Camera").GetComponent<PolygonCollider2D>();

        if (playerCamera != null && cameraBounds != null) 
        {
            playerCamera.BoundingShape2D = cameraBounds;
        }
    }
    
    void TarotCheck()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        GameObject tarot1;
        GameObject tarot2;
        GameObject tarot3;

        tarot1 = GameObject.Find("Tarots 1");
        tarot2 = GameObject.Find("Tarots 2");
        tarot3 = GameObject.Find("Tarots 3");

        if (tarot1 != null)
        {
            if (currentScene.name == "Level1")
            {
                foreach (Transform child in tarot1.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (Transform child in tarot1.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        if (tarot2 != null)
        {
            if (currentScene.name == "Level 2")
            {
                foreach (Transform child in tarot2.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (Transform child in tarot2.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        if (tarot3 != null)
        {
            if (currentScene.name == "Level 3")
            {
                foreach (Transform child in tarot3.transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (Transform child in tarot3.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
