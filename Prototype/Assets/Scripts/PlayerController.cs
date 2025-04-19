using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input
    public InputAction moveAction; // Input action for movement
    public InputAction attackAction; // Input action for attack

    // Movement
    public float moveSpeed = 5f; // Speed of the player

    // Animations
    public Animator animator; // Animator component

    // Cooldown
    public float staminaTime = 3f;
    float staminaCooldown = 0f;
    bool hasStamina;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the move action to start receiving input
        attackAction.Enable(); // Enable the attack action to start receiving input

        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call the MovePlayer method to handle movement
        AnimatePlayer(); // Call the AnimatePlayer method to handle animation

        StaminaCooldown();
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
        //if (moveAction.ReadValue<Vector2>().y < 0) // Check if moving down
        if (moveAction.name == "Down")
        {
            animator.SetBool("isDown", true); // Set animator parameter for down movement
        }
        else
        {
            animator.SetBool("isDown", false); // Reset animator parameter for down movement
        }
    }

    // Stamina cooldown and check
    void StaminaCooldown()
    {
        if ((staminaCooldown <= 0f) && (hasStamina == false))
        {
            hasStamina = true;
            staminaCooldown = staminaTime;
        }
        else
        {
            staminaCooldown -= Time.deltaTime;
        }
    }

    //Player attacking
    public int Attack()
    {
        if (attackAction.IsPressed())
        {
            if (hasStamina)
            {
                hasStamina = false;
                return 5;
            }
        }

        return 0;
    }
}
