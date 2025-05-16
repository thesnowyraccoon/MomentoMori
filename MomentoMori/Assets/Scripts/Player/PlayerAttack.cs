using UnityEngine;
using UnityEngine.InputSystem;

// Title: Melee & Ranged Top Down Combat - Unity 2D
// Author: Game Code Library
// Date: August 10 2023
// Code version: Unknown
// Availability: https://youtu.be/-4bsGg7dVFo?si=z3A91GlWMENwUL_P

public class PlayerAttack : MonoBehaviour
{
    public InputAction attackAction; // Input action for attack

    public GameObject sword;
    public Animator animator;

    private bool isAttacking = false;
    private float attackDuration = 0.3f;
    private float attackTimer = 0f;

    void Start()
    {
        attackAction.Enable(); // Enable the attack action to start receiving input
    }

    void Update()
    {
        AttackTimer();

        if (attackAction.triggered)
        {
            OnAttack();
        }
    }

    void OnAttack()
    {
        if (!isAttacking)
        {
            sword.SetActive(true);
            isAttacking = true;
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    void AttackTimer()
    {
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
