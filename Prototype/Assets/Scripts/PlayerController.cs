using UnityEngine;
using UnityEngine.InputSystem; // Import the Unity Input System namespace

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction; // Input action for movement
    public float moveSpeed = 5f; // Speed of the player movement

    public Animator animator; // Reference to the Animator component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the move action to start receiving input

        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
    }

    void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero; // Initialize move direction

        if (moveAction.ReadValue<Vector2>().x > 0) // Check if moving right
        {
            moveDirection.x += 1;
        }
        else if (moveAction.ReadValue<Vector2>().x < 0) // Check if moving left
        {
            moveDirection.x -= 1;
        }
        else if (moveAction.ReadValue<Vector2>().y > 0) // Check if moving up
        {
            moveDirection.y += 1;
        }
        else if (moveAction.ReadValue<Vector2>().y < 0) // Check if moving down
        {
            moveDirection.y -= 1;
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime; // Move the player based on input
    }

    void AnimatePlayer()
    {
        if (moveAction.ReadValue<Vector2>().x > 0) // Check if moving right
        {
            animator.SetBool("isRight", true); // Set animator parameter for right movement
        }
        else
        {
            animator.SetBool("isRight", false); // Reset animator parameter for right movement
        }
        if (moveAction.ReadValue<Vector2>().x < 0) // Check if moving left
        {
            animator.SetBool("isLeft", true); // Set animator parameter for left movement
        }
        else
        {
            animator.SetBool("isLeft", false); // Reset animator parameter for left movement
        }
        if (moveAction.ReadValue<Vector2>().y > 0) // Check if moving up
        {
            animator.SetBool("isUp", true); // Set animator parameter for up movement
        }
        else
        {
            animator.SetBool("isUp", false); // Reset animator parameter for up movement
        }
        if (moveAction.ReadValue<Vector2>().y < 0) // Check if moving down
        {
            animator.SetBool("isDown", true); // Set animator parameter for down movement
        }
        else
        {
            animator.SetBool("isDown", false); // Reset animator parameter for down movement
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call the MovePlayer method to handle movement
        AnimatePlayer(); // Call the AnimatePlayer method to handle animation
    }
}
