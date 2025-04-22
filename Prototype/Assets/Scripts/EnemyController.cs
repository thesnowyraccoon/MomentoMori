using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Enemy stats
    public float enemyHealth = 100;
    TextMeshPro health;

    public float attack = 5;

    float cooldown = 0f;
    public float stamina = 5f;
    bool hasStamina = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponentInChildren<TextMeshPro>(); // Assigns health to the text component
        health.text = "Health: " + enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Stamina();

        if (enemyHealth <= 0)   // Checks health and destroys if dead
        {
            Destroy(gameObject); 
        }
    }

    // Checks if player attacks and applies damage
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            float damage = trigger.GetComponent<PlayerController>().Attack();

            enemyHealth -= damage;
            health.text = "Health: " + enemyHealth; 

            if (hasStamina)
            {
                trigger.GetComponent<PlayerController>().playerHealth -= attack;

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
