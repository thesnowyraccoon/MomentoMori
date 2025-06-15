using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public bool areEnemies;

    void Update()
    {
        areEnemies = transform.childCount > 0;
    }
}
