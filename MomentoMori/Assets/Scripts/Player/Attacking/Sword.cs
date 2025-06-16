using UnityEngine;

// Title: Melee & Ranged Top Down Combat - Unity 2D
// Author: Game Code Library
// Date: August 10 2023
// Code version: Unknown
// Availability: https://youtu.be/-4bsGg7dVFo?si=z3A91GlWMENwUL_P

public class Sword : MonoBehaviour
{
    [SerializeField] private PlayerAttack swordDamage; // Weapon damage

    // Checks if weapon interacting with enemy and deals damage accordingly
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            CrowMovement crow = collision.GetComponent<CrowMovement>();
            FloweyController flowey = collision.GetComponent<FloweyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(swordDamage.GetAttack());
            }

            if (crow != null)
            {
                crow.TakeDamage(swordDamage.GetAttack());
            }

            if (flowey != null)
            {
                flowey.TakeDamage(swordDamage.GetAttack());
            }
        }
        else if (collision.CompareTag("Boss"))
        {
            BossController boss = collision.GetComponent<BossController>();

            if (boss != null)
            {
                boss.TakeDamage(swordDamage.GetAttack());
            }
        }
    }
}
