using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Damaged(damage);
            }
        }
    }
}
