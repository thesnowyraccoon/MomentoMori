using UnityEngine;

// Title: Melee & Ranged Top Down Combat - Unity 2D
// Author: Game Code Library
// Date: August 10 2023
// Code version: Unknown
// Availability: https://youtu.be/-4bsGg7dVFo?si=z3A91GlWMENwUL_P

public class Sword : MonoBehaviour
{
    [SerializeField] private int swordDamage = 1; // Player damage

    // Checks if weapon interacting with enemy and deals damage accordingly
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(swordDamage);
            }
        }
    }

    // Adds attack damage
    public void AddDamage(int damage)
    {
        swordDamage += damage;
    }
}
