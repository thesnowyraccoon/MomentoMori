using UnityEngine;

public class Collectable : MonoBehaviour
{
    // interactable stats
    public int collectableHealth = 10;
    
    // player stats
    float playerHealth;
    float maxHealth;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // checks player max health

            if (player != null)
            {
                maxHealth = player.GetComponent<PlayerController>().maxHealth;
            }

            playerHealth = trigger.gameObject.GetComponent<PlayerController>().playerHealth; // gets player health
            
            if (playerHealth < maxHealth)
            {
                playerHealth += collectableHealth;
                
                trigger.gameObject.GetComponent<PlayerController>().playerHealth = playerHealth; // sets new player health

                Destroy(gameObject);
            }
        }
    }
}
