using UnityEngine;

//2D Enemy Shooting Unity Tutorial
//MoreBBlakeyyy
//2 October 2022
//https://youtu.be/--u20SaCCow?si=X90PQCxBsDVsuZEP
public class Projectiles : MonoBehaviour
{
    public GameObject pellet;
    public Transform pelletPos;
    private GameObject player;

    public Animator animator;

    private float timer;

    public float playerDistance = 9;
    public float cooldown = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position); //distance enemy shoots

        if (distance < playerDistance)
        {
            timer += Time.deltaTime;

            if (timer > cooldown) //If 2 seconds pass, adjustable in inspec
            {
                if (animator != null)
                {
                    animator.SetBool("isAttacking", true);
                }
                
                Shoot();
                timer = 0; //Timer resets
            }
            else
            {
                if (animator != null)
                {
                    animator.SetBool("isAttacking", false);
                }
            }
        }
    }

    void Shoot()
    {
        Instantiate(pellet, pelletPos.position, Quaternion.identity);
    }
}
