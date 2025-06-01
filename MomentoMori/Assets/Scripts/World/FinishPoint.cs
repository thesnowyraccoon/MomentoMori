using System.Dynamic;
using UnityEditor.SearchService;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public PlayerController player; //refers to the player controller script
    private int health;
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
    void Update()
    {
        health = player.GetHealth();

        if (health == 0)
        {
            SceneController.instance.LoadScene("Home");
        }
    }

}
