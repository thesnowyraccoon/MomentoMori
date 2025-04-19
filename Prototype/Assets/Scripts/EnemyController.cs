using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    int enemyHealth = 100;
    int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            damage = trigger.GetComponent<PlayerController>().Attack();

            if (damage > 0)
            {
                enemyHealth -= damage;
                print("Enemy Health: " + enemyHealth);
            }
        }
    }
}
