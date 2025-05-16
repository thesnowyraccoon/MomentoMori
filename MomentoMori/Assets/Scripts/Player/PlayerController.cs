using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input
    public InputAction moveAction; // Input action for movement
    public InputAction interactAction; // Input action for interactions
    public InputAction pauseAction; // Input action for pausing the game

    private Vector2 _boxSize = new Vector2(0.1f, 1f);

    // Movement
    public float moveSpeed = 5f; // Speed of the player
    float lastX = 0, lastY = 0;
    bool isMoving = false;

    // Attacking 
    public Transform aim;

    // Animations
    [SerializeField] private Animator animator; // Animator component
    [SerializeField] private SpriteRenderer playerSR;

    // Stats
    [HideInInspector] public int maxHealth = 100;
    public enum MaximumHealth {Ten, Twenty, Thirty, Forty, Fifty};
    public MaximumHealth maximumHealth;
    public int playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the move action to start receiving input
        interactAction.Enable();
        pauseAction.Enable();

        animator = GetComponent<Animator>(); // Get the Animator component attached to the player

        playerHealth = maxHealth; // sets playerhealth to maximum\
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call to handle movement and animation
        Interaction(); // Call to check if interacting
        Pause();

        HealthMax();
        Health(); // Call to check health, and to set and animate accordingly
    }

    // Player movement
    void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero; // Initialize move direction

        isMoving = false;

        // Checks for WASD movement in 4 directions and animates accordingly
        if (moveAction.ReadValue<Vector2>().x > 0)
        {
            moveDirection.x += 1;

            lastX = 1;
            lastY = 0;

            isMoving = true;
        }
        else if (moveAction.ReadValue<Vector2>().x < 0)
        {
            moveDirection.x -= 1;

            lastX = -1;
            lastY = 0;

            isMoving = true;
        }
        else if (moveAction.ReadValue<Vector2>().y > 0)
        {
            moveDirection.y += 1;

            lastX = 0;
            lastY = 1;

            isMoving = true;
        }
        else if (moveAction.ReadValue<Vector2>().y < 0)
        {
            moveDirection.y -= 1;

            lastX = 0;
            lastY = -1;

            isMoving = true;
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime; // Move the player based on input

        animator.SetFloat("X", moveDirection.x);
        animator.SetFloat("Y", moveDirection.y);

        if (isMoving == false)
        {
            animator.SetFloat("lastX", lastX);
            animator.SetFloat("lastY", lastY);
        }

        animator.SetBool("isMoving", isMoving);

        // Title: Melee & Ranged Top Down Combat - Unity 2D
        // Author: Game Code Library
        // Date: August 10 2023
        // Code version: Unknown
        // Availability: https://youtu.be/-4bsGg7dVFo?si=z3A91GlWMENwUL_P

        if (isMoving)
        {
            Vector3 vector3 = Vector3.left * moveDirection.x + Vector3.down * moveDirection.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    public void Damaged(int damage)
    {
        playerHealth -= damage;
    }

    void HealthMax()
    {
        if (maximumHealth == MaximumHealth.Ten)
        {
            maxHealth = 10;
        }
        else if (maximumHealth == MaximumHealth.Twenty)
        {
            maxHealth = 20;
        }
        else if (maximumHealth == MaximumHealth.Thirty)
        {
            maxHealth = 30;
        }
        else if (maximumHealth == MaximumHealth.Forty)
        {
            maxHealth = 40;
        }
        else if (maximumHealth == MaximumHealth.Fifty)
        {
            maxHealth = 50;
        }
    }

    // Player health display and check
    void Health()
    {
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        if (playerHealth <= 0)
        {
            playerSR.enabled = false;
            moveAction.Disable();
        }
    }

    void Pause()
    {
        if (pauseAction.triggered)
        {
            PauseMenu pause = GameObject.Find("Pause UI").GetComponent<PauseMenu>();
            pause.Open();

            Time.timeScale = 0f; // Stop game time
        }
    }

    // Title: How to Interact With Game Objects [Unity Tutorial]
    // Author: Comp-3 Interactive 
    // Date: April 24 2020
    // Code version: Unknown
    // Availability: https://youtu.be/GaVADPZlO0o?si=0MwOBmMmnPj6RDBl
    
    public void OpenInteractableIcon()
    {
        // Set interactable icon active
    }

    public void CloseInteractableIcon()
    {
        // Set interactable icon false
    }

    void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, _boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach(RaycastHit2D raycast in hits)
            {
                if (raycast.transform.GetComponent<Interactions>())
                {
                    raycast.transform.GetComponent<Interactions>().Interact();
                    return;
                }
            }
        }
    }

    void Interaction()
    {
        if (interactAction.triggered)
        {
            CheckInteraction();
        }
    }
}
