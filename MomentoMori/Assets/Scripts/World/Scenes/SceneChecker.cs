using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    void Start()
    {
        SetCamera();
        TarotCheck();
    }

    void SetCamera()
    {
        GameObject player = GameObject.Find("PlayerCamera");
        GameObject bounds = GameObject.Find("Camera");

        if (player != null && bounds != null) 
        {
            CinemachineConfiner2D playerCamera = player.GetComponent<CinemachineConfiner2D>();
            PolygonCollider2D cameraBounds = bounds.GetComponent<PolygonCollider2D>();

            playerCamera.GetComponent<CinemachineConfiner2D>().BoundingShape2D = cameraBounds;
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
