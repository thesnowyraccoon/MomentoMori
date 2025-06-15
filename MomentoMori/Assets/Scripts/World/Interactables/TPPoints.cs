using UnityEngine;
using UnityEngine.SceneManagement;

public class TPPoints : Interactions
{
    public string levelName;
    public bool confirm = false;

    public EnemyCheck enemies;

    public override void Interact()
    {
        if (!confirm)
        {
            SceneController.instance.LoadScene(levelName);
        }
        else
        {
            if (enemies.areEnemies == false)
            {
                SceneController.instance.LoadScene(levelName);
            }
            else
            {
                Debug.Log("No Entry!");
            }
        }
    }
}
