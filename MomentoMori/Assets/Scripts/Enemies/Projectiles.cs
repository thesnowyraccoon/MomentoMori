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

    public float distance;
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position); //distance enemy shoots

        if (distance < 9)
        {
            timer += Time.deltaTime;

            if (timer > 2) //If 2 seconds pass, adjustable in inspec
            {
                timer = 0; //Timer resets
                shoot();
            }
        }


    }

    void shoot()
    {
        Instantiate(pellet, pelletPos.position, Quaternion.identity);
    }
}
