using System.Dynamic;
using UnityEditor.SearchService;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    //collision with a teleport point
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (goNextLevel)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                SceneController.instance.LoadScene(levelName); //Load Level By its name, Useful in terms of the player dying
            }

        }
    }
    private void PlayerDies()
    {   
        
        {
            
        }
    }

}
