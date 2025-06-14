using System.Collections;
using UnityEngine;

// Title: How to make a BOSS in Unity!
// Author: Brackeys
// Date: January 26 2020
// Code version: Unknown
// Availability: https://youtu.be/AD4JIXQDw0s?si=6hfV5X20wXlI3O14

public class BossController : MonoBehaviour
{
    // Health
    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 50;

    [SerializeField] private Collider2D wing;
    [SerializeField] private Collider2D head;
    [SerializeField] private Collider2D staff;

    void Start()
    {
        health = maxHealth;
    }

    public void WingAttack()
    {
        wing.enabled = !wing.enabled;
    }

    public void HeadAttack()
    {
        head.enabled = !head.enabled;
    }

    public void StaffAttack()
    {
        staff.enabled = !staff.enabled;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

