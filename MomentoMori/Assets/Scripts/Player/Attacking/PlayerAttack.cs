using UnityEngine;
using UnityEngine.InputSystem;

// Title: Melee & Ranged Top Down Combat - Unity 2D
// Author: Game Code Library
// Date: August 10 2023
// Code version: Unknown
// Availability: https://youtu.be/-4bsGg7dVFo?si=z3A91GlWMENwUL_P

public class PlayerAttack : MonoBehaviour
{
    [Header("Input")]
    public InputAction attackAction; // Input action for attack

    // Reference to the weapon
    [Header("Sword")]
    public GameObject sword;
    public Animator animator;

    // Attacking 
    [Header("Attack")]
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackDuration = 0.3f;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    void Start()
    {
        attackAction.Enable(); // Enable the attack action to start receiving input
    }

    public void AddAttack(int damage)
    {
        attackDamage += damage;
    }

    public int GetAttack()
    {
        return attackDamage;
    }

    public void OnAttack()
    {
        // Checks if player is currently attacking and attacks accordingly
        if (!isAttacking)
        {
            sword.SetActive(true);
            isAttacking = true;
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    public void AttackTimer()
    {
        // Attack timer for length of each attack
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDuration)
            {
                attackTimer = 0;
                isAttacking = false;
                sword.SetActive(false);
            }
        }
    }
}
