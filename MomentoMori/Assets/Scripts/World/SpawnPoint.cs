using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.scene.isLoaded)
        {
            Debug.Log("Player Spawned");

            player = GameObject.FindGameObjectWithTag("Player").transform;

            player.position = transform.position;
        }
        else
        {
            Debug.Log("Scene is not loaded.");
        }
    }
}
