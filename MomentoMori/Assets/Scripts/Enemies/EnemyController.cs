using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Player stats
    public PlayerController player;
    private int playerHealth;
    private int playerMaxHealth;

    // Enemy stats
    public int health = 100;

    public int attack = 5;

    float cooldown = 0f;
    public float stamina = 5f;
    bool hasStamina = true;

    // Update is called once per frame
    void Update()
    {
        Stamina();

        playerHealth = player.playerHealth;
        playerMaxHealth = player.maxHealth;

        if (health <= 0)   // Checks health and destroys if dead
        {
            Destroy(gameObject); 
        }
    }

    // Checks if player attacks and applies damage
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            health -= player.Attack();

            if (hasStamina)
            {
                playerHealth -= attack;
                player.playerHealth = playerHealth;

                hasStamina = false;
            }
        }
    }

    void Stamina()
    {
        if ((cooldown <= 0f) && (hasStamina == false))
        {
            hasStamina = true;
            cooldown = stamina;
        }
        else
        {
            cooldown -= Time.deltaTime;
            
            if (cooldown < 0f)
            {
                cooldown = 0f;
            }
        }
    }
}
