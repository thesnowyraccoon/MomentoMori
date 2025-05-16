using UnityEngine;

// Title: Melee & Ranged Top Down Combat - Unity 2D
// Author: Game Code Library
// Date: August 10 2023
// Code version: Unknown
// Availability: https://youtu.be/-4bsGg7dVFo?si=z3A91GlWMENwUL_P

public class Sword : MonoBehaviour
{
    public int playerDamage = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(playerDamage);
            }
        }
    }
}
