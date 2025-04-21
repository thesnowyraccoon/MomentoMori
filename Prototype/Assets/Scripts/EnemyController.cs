using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Enemy stats
    public float enemyHealth = 100;
    TextMeshPro health;

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
        if (trigger.gameObject.CompareTag("Player"))
        {
            float damage = trigger.GetComponent<PlayerController>().Attack();

            enemyHealth -= damage;
            health.text = "Health: " + enemyHealth; 
        }
    }
}
