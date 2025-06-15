using UnityEngine;

public class SceneCheck : MonoBehaviour
{
    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.scene.isLoaded)
        {
            Debug.Log("Scene is loaded.");

            player = GameObject.FindGameObjectWithTag("Player").transform;

            player.position = transform.position;
        }
        else
        {
            Debug.Log("Scene is not loaded.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
