using UnityEngine;

//2D Enemy Shooting Unity Tutorial
//MoreBBlakeyyy
//2 October 2022
//https://youtu.be/--u20SaCCow?si=X90PQCxBsDVsuZEP

public class EnemyBullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public float lifespan = 3f;
    public int damage = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > lifespan) //6 seconds pass, ensure that the pellets arent always in game 
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) //Destroys pellet when contact with player
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().Damaged(damage); //Deals damage
            Destroy(gameObject);
        }
    }
}
