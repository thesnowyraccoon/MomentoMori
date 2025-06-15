
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    //Most of this script has been taken out of the enemy controller script (Find refernces there)
    // Health
    [Header("Player")]
    public GameObject player;

    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;

    //Header
    [Header("Particle")]
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem damageParticlesInstance;


    //Title:Week 14 - Polymorphism & Overriding & Raycasting
    //Author:HAyes, A.
    //Date: 2025
    //Code version: Unknown
    //Availability: Lecture slides University of Witswatersrand

    public LayerMask groundLayer;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        player = GameObject.Find("playerRemy");

        health = maxHealth; // Sets enemy health to max
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Debug.DrawRay(gameObject.transform.position, Vector2.down * 2, Color.red);

        RaycastHit2D groundInfo = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 2f, groundLayer);

        if (groundInfo.collider == false)
        {
            transform.Rotate(0f, 180f, 0f);
        }

        void Move()
        {
            transform.Translate(Vector2.right * 2.0f * Time.deltaTime);

            animator.SetBool("isMoving", true);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        SpawnDamageParticles(); //Spawns in particles

        if (health <= 0)
        {
            Destroy(transform.parent.gameObject); // Enemy dies when health is zero
        }
    }

    private void SpawnDamageParticles()
    {
        damageParticlesInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);
    }

}
