using UnityEngine;
using UnityEngine.SceneManagement;

public class TPPoints : Interactions
{
    public bool confirm = false;
    public bool tarot = false;

    public EnemyCheck enemies;

    private HotBarController hotBar;

    public override void Interact()
    {
        if (!confirm)
        {
            SceneController.instance.NextLevel();
        }
        else
        {
            if (enemies.areEnemies == false)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                Debug.Log("No Entry!");
            }
        }

        if (tarot)
        {
            hotBar = FindAnyObjectByType<HotBarController>();
            hotBar.UseItemInSlot(0);
        }
    }
}
