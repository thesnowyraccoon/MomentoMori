using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Player stats
    private PlayerController player;

    //Animations
    [SerializeField] private Animator owl;

    // Enemy stats
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int attack = 5;

    void Start()
    {
        health = maxHealth; // Sets enemy health to max
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
            player = trigger.GetComponent<PlayerController>();

            owl.SetBool("isAttacking", true);

            player.Damaged(attack);
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            owl.SetBool("isAttacking", false);
        }
    }
}
