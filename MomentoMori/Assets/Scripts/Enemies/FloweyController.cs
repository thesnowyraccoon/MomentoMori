using UnityEngine;

public class FloweyController : MonoBehaviour
{
    [SerializeField] int health = 15;

    DialogueUI dialogue;

    //Header
    [Header("Particle")]
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem damageParticlesInstance;

    void Start()
    {
        dialogue = FindAnyObjectByType<DialogueUI>();
    }

    void Update()
    {
        if (health <= 0)
        {
            dialogue.hasAttacked = true;
            
            Destroy(gameObject); // Enemy dies when health is zero
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        SpawnDamageParticles(); //Spawns in particles
    }

    private void SpawnDamageParticles()
    {
        damageParticlesInstance = Instantiate(damageParticles, transform.position, Quaternion.identity);
    }
}
