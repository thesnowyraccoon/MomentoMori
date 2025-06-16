using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Health
    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 50;

    // Attack
    [Header("Attacking")]
    public float attackCooldown = 5f;

    // Colliders
    [Header("Colliders")]
    [SerializeField] private Collider2D wing;
    [SerializeField] private Collider2D head;
    [SerializeField] private Collider2D staff;

    //Particle Effect
    [Header("Particle")]
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem damageParticlesInstance;

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

        SpawnDamageParticles(); //Spawns in particles

        if (health <= 0)
        {
           // SoundEffectManager.Play("Scream");

            Destroy(gameObject);

            SceneController.instance.NextLevel();
        }
    }

     private void SpawnDamageParticles()
    {
        damageParticlesInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);
    }
}