using System;
using UnityEngine;

public class Melatonin : MonoBehaviour
{
    // Collectable health stats
    [SerializeField] private int collectableHealth = 10;
    
    // Player stats
    private int playerHealth;
    private int maxHealth;
    private PlayerController player;

    public void SetHealth(int health)
    {
        collectableHealth = health;
    }

    internal int SetHealth()
    {
        throw new NotImplementedException();
    }

    // Check for player and if they can pick up collectable health
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            player = trigger.GetComponent<PlayerController>();

            if (player != null) // If player exists get health values
            {
                maxHealth = player.GetMaxHealth(); // Gets player max health
                playerHealth = player.GetHealth(); // Gets player current health
            }

            if (playerHealth < maxHealth) // Checks if player can recieve health
            {
                player.HealthGain(collectableHealth); // sets new player health

                Destroy(gameObject);
            }
            
            // trigger pickup sound
        }
    }
}
