using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Enemy stats
    public int enemyHealth = 100;
    TextMeshPro health;

    // Player damage
    int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponentInChildren<TextMeshPro>(); // Assigns health to the text component
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)   // Checks health and destroys if dead
        {
            Destroy(gameObject); 
        }
    }

    // Checks if player attacks and applies damage
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            damage = trigger.GetComponent<PlayerController>().Attack();

            if (damage > 0)
            {
                enemyHealth -= damage;
                health.enabled = true;
                health.text = "Health: " + enemyHealth;
            }
        }
    }
}
