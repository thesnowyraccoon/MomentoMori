using UnityEngine;

// Title: Unity simple 2D Enemy AI Follow Tutorial
// Author: MoreBBlakeyyy
// Date: January 16 2022
// Code version: Unknown
// Availability: https://youtu.be/2SXa10ILJms?si=KZOIwdMGhyOFhOHg

public class EnemyController : MonoBehaviour
{
    // Player
    public GameObject player;

    private bool hasPlayer = false;

    // Following stats
    private float distance;
    private Vector2 direction;
    [SerializeField] private float followDistance = 4;

    // Animations
    [SerializeField] private Animator owl;
    private bool isMoving = false;
    private float X = 0, Y = 0;

    // Health
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;

    // Attack
    [SerializeField] private int attack = 5;

    // Attacking 
    private bool isAttacking = false;
    [SerializeField] private float attackDuration = 0.3f;
    private float attackTimer = 0f;

    // Speed
    [SerializeField] private float speed;

    void Start()
    {
        health = maxHealth; // Sets enemy health to max
    }

    void Update()
    {
        Follow();

        AttackTimer(); // Initiates time and check for each attack

        if (hasPlayer == true)
        {
            OnAttack(); // Activates attack
        }
    }

    public void OnAttack()
    {
        // Checks if player is currently attacking and attacks accordingly
        if (!isAttacking)
        {
            player.GetComponent<PlayerController>().Damaged(attack);
            isAttacking = true;
            owl.SetBool("isAttacking", isAttacking);
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
                owl.SetBool("isAttacking", isAttacking);
            }
        }
    }

    void Follow()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < followDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            direction = (player.transform.position - transform.position).normalized;

            isMoving = true;

            X = direction.x;
            Y = direction.y;

            owl.SetBool("isMoving", isMoving);
            owl.SetFloat("X", X);
            owl.SetFloat("Y", Y);
        }
        else
        {
            direction = Vector2.zero;

            isMoving = false;
            owl.SetBool("isMoving", isMoving);
        }
    }

    // Enemy takes damage on hit
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject); // Enemy dies when health is zero
        }
    }

    // Checks if near player and deals damage accordingly
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}
