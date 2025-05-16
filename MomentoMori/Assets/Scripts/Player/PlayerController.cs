using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input
    public InputAction moveAction; // Input action for movement
    public InputAction attackAction; // Input action for attack
    public InputAction interactAction; // Input action for interactions
    public InputAction pauseAction; // Input action for pausing the game

    private Vector2 _boxSize = new Vector2(0.1f, 1f);

    // Movement
    public float moveSpeed = 5f; // Speed of the player

    // Animations
    [SerializeField] private Animator animator; // Animator component
    [SerializeField] private SpriteRenderer playerSR;

    // Stats
    [HideInInspector] public int maxHealth = 100;
    public enum MaximumHealth {Ten, Twenty, Thirty, Forty, Fifty};
    public MaximumHealth maximumHealth;
    public int playerHealth;
    public int playerDamage = 5;

    // Stamina
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the move action to start receiving input
        attackAction.Enable(); // Enable the attack action to start receiving input
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

    // player movement
    void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero; // Initialize move direction

        // Checks for WASD movement in 4 directions and animates accordingly
        if (moveAction.ReadValue<Vector2>().x > 0)
        {
            moveDirection.x += 1;

            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);

        }
        else if (moveAction.ReadValue<Vector2>().x < 0)
        {
            moveDirection.x -= 1;

            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
        }
        else if (moveAction.ReadValue<Vector2>().y > 0)
        {
            moveDirection.y += 1;

            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 0);
        }
        else if (moveAction.ReadValue<Vector2>().y < 0)
        {
            moveDirection.y -= 1;

            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 0);
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime; // Move the player based on input
    }

    // Player attacking
    public int Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 5f); // Adjust radius as needed

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                if (attackAction.IsPressed())
                {
                    return playerDamage;
                }
            }
        }

        return 0;
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
