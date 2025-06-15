
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
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
}
