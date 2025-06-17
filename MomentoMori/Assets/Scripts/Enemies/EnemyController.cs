using System.Collections;
using UnityEngine;

// Title: Unity simple 2D Enemy AI Follow Tutorial
// Author: MoreBBlakeyyy
// Date: January 16 2022
// Code version: Unknown
// Availability: https://youtu.be/2SXa10ILJms?si=KZOIwdMGhyOFhOHg

public class EnemyController : MonoBehaviour
{
    // Player
    [Header("Player")]
    public GameObject player;

    private bool hasPlayer = false;

    // Animations
    [Header("Animations")]
    [SerializeField] private Animator enemy;
    private bool isMoving = false;
    private float X = 0, Y = 0;

    // Following stats
    [Header("Following")]
    private float distance;
    private Vector2 direction;
    [SerializeField] private float followDistance = 4;

    // Speed
    [Header("Speed")]
    [SerializeField] private float speed;

    // Health
    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;

    // Attack
    [Header("Attack")]
    [SerializeField] private int attack = 5;

    // Attacking 
    private bool isAttacking = false;
    [SerializeField] private float attackDuration = 0.3f;
    private float attackTimer = 0f;
    [SerializeField] private float attackCost;

    private Coroutine recharge;

    // Cooldown
    [Header("Cooldown")]
    [SerializeField] private float cooldown, maxCooldown;
    [SerializeField] private float chargeRate;
    private bool hasAttack = true;

    //Learn EVERYTHING About Particles in Unity|Easy Tutorial
    //1 December 2022
    //Sasquatch B Studios
    //https://youtu.be/0HKSvT2gcuk?si=mdvnt9gmoj4TxuaC

    //Particle Effect
    [Header("Particle")]
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem damageParticlesInstance;

    void Start()
    {
        player = GameObject.Find("playerRemy");
        enemy = GetComponent<Animator>();

        health = maxHealth; // Sets enemy health to max
        cooldown = maxCooldown;
    }

    void Update()
    {
        Follow();

        AttackTimer(); // Initiates time and check for each attack

        if (hasPlayer == true && hasAttack == true)
        {
            OnAttack(); // Activates attack

            cooldown -= attackCost; // Attacks use stamina

            if (recharge != null) // Checks and initiates cooldown before recharging stamina
            {
                StopCoroutine(recharge);
            }

            recharge = StartCoroutine(RechargeStamina()); // Stamina recharges
        }

        if (cooldown < 0) // Ensures stamina not below 0
        {
            cooldown = 0;
        }

        if (cooldown > maxCooldown) // Ensures stamina not above max
        {
            cooldown = maxCooldown;
        }

        if (cooldown < attackCost)
        {
            hasAttack = false;
        }

        if (cooldown >= attackCost)
        {
            hasAttack = true;
        }
    }

    private IEnumerator RechargeStamina() // Stamina recharges after a short duration after attacking
    {
        yield return new WaitForSeconds(1f);

        while (cooldown < maxCooldown)
        {
            cooldown += chargeRate / 10f;

            yield return new WaitForSeconds(.1f);
        }
    }

    public void OnAttack()
    {
        // Checks if player is currently attacking and attacks accordingly
        if (!isAttacking)
        {
            player.GetComponent<PlayerController>().Damaged(attack);
            isAttacking = true;
            enemy.SetBool("isAttacking", isAttacking);
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
                enemy.SetBool("isAttacking", isAttacking);
            }
        }
    }

    void Follow()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < followDistance)
        {
            SoundEffectManager.Play("EnemyFollow", true); 
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            direction = (player.transform.position - transform.position).normalized;

            isMoving = true;

            X = direction.x;
            Y = direction.y;

            enemy.SetBool("isMoving", isMoving);
            enemy.SetFloat("X", X);
            enemy.SetFloat("Y", Y);
        }
        else
        {
            direction = Vector2.zero;

            isMoving = false;
            enemy.SetBool("isMoving", isMoving);
        }
    }

    // Enemy takes damage on hit
    public void TakeDamage(int damage)
    {
        health -= damage;

        SpawnDamageParticles(); //Spawns in particles

        if (health <= 0)
        {
            Destroy(gameObject); // Enemy dies when health is zero
        }
    }

    // Checks if near player and deals damage accordingly
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }

    private void SpawnDamageParticles()
    {
        damageParticlesInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);
    }


}
