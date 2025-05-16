using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Player stats
    public PlayerController player;

    // Enemy stats
    public int health;
    public int maxHealth = 100;
    public int attack = 5;

    void Start()
    {
        health = maxHealth;
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
