using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    GameObject player;

    [SerializeField] private bool health = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.scene.isLoaded)
        {
            Debug.Log("Player Spawned");

            player = GameObject.FindGameObjectWithTag("Player");

            player.transform.position = transform.position;

            if (health)
            {
                player.GetComponent<PlayerController>().HealthGain(50);
            }
        }
        else
        {
            Debug.Log("Scene is not loaded.");
        }
    }
}
