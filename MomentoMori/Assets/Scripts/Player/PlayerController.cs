using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Input
    [Header("Input")]
    public InputAction moveAction; // Input action for movement
    public InputAction dashAction; // Input action for dashing
    public InputAction interactAction; // Input action for interactions
    public InputAction tarotAction;
    public InputAction pauseAction; // Input action for pausing the game

    private Vector2 _boxSize = new Vector2(0.1f, 1f); // Interaction distance

    // Movement
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f; // Speed of the player

    private Vector3 moveDirection;

    private float lastX = 0, lastY = 0; // Last position player was facing
    private bool isMoving = false; // Movement check

    // Dashing
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashLength = 0.5f;

    private float activeMoveSpeed;
    private float dashCounter;

    // Animations
    [Header("Animations")]
    [SerializeField] private Animator animator; // Animator component
    [SerializeField] private SpriteRenderer playerSR; // Player renderer

    // Interaction Icon
    [Header("Interactions")]
    [SerializeField] private GameObject interactionIcon;

    // Stats
    [Header("Health")]
    public MaximumHealth maximumHealth;
    public enum MaximumHealth { Ten, Twenty, Thirty, Forty, Fifty }; // Specific player max health

    private int maxHealth = 10;
    [SerializeField] private int playerHealth = 10; // Player current health

    // Attacking 
    [Header("Attacking")]
    public Transform aim; // Direction of player attack

    //Particle
    [Header("Particle")]
    [SerializeField] private ParticleSystem dashParticles;
    private ParticleSystem dashParticlesInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the movement inputs
        dashAction.Enable();
        interactAction.Enable(); // Enable interaction input
        tarotAction.Enable();
        pauseAction.Enable(); // Enable pause inputs

        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
        playerSR = GetComponent<SpriteRenderer>();

        playerHealth = maxHealth; // Sets player health to maximum

        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call to handle movement and animation
        Dashing();
        Interaction(); // Call to check if interacting
        Pause(); // Call to check if pausing

        HealthMax(); // Set player max health values
        Health(); // Call to check health, and to set and animate accordingly
    }

    // Player movement
    void MovePlayer()
    {
        moveDirection = Vector3.zero; // Initialize move direction

        isMoving = false; // Sets moving to false when not moving 

        // Checks for WASD movement in 4 directions and animates accordingly
        // Saves last postions and sets moving to true
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

        transform.position += moveDirection.normalized * activeMoveSpeed * Time.deltaTime; // Move the player based on input

        // Moving animations
        animator.SetFloat("X", moveDirection.x);
        animator.SetFloat("Y", moveDirection.y);

        // Saves last movement for idle animations
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

        // Sets direction of player attack
        if (isMoving)
        {
            Vector3 vector3 = Vector3.left * moveDirection.x + Vector3.down * moveDirection.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    // Title: 
    // Author: Jake Makes Games
    // Date: July 19 2021
    // Code version: Unknown
    // Availability:

    public void Dash()
    {
        if (dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            SpawnDashParticles(); //Spawns in particles
        }
    }

    void Dashing()
    {
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
            }
        }
    }

    public void DashGain(float gain)
    {
        dashSpeed += gain;
    }

    // Sets player speed in external operations
    public void AddSpeed(float speed)
    {
        moveSpeed += speed;
    }

    // Player recieving damage
    public void Damaged(int damage)
    {
        playerHealth -= damage;
    }

    // Player recieving health
    public void HealthGain(int health)
    {
        playerHealth += health;
    }

    // Gets player health for other operations
    public int GetHealth()
    {
        return playerHealth;
    }

    // Gets player max health for other operations
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    // Player max health enum
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

        if (playerHealth <= 0) // Player disable on death // Should be reset to start
        {
            //playerSR.enabled = false;
            //moveAction.Disable();
            //Time.timeScale = 0f;

            SceneManager.LoadSceneAsync("World");
        }
    }

    // Pause menu activation
    void Pause()
    {
        if (pauseAction.triggered)
        {
            Canvas pause = GameObject.Find("Canvas (PauseMenu)").GetComponent<Canvas>();

            if (pause.enabled == false)
            {
                pause.enabled = true;

                Time.timeScale = 0f; // Stop game time
            }
            else if (pause.enabled == true)
            {
                pause.enabled = false;

                Time.timeScale = 1f; // Start game time
            }
        }
    }

    // Title: How to Interact With Game Objects [Unity Tutorial]
    // Author: Comp-3 Interactive 
    // Date: April 24 2020
    // Code version: Unknown
    // Availability: https://youtu.be/GaVADPZlO0o?si=0MwOBmMmnPj6RDBl

    // Displays icon when able to interact
    public void OpenInteractableIcon()
    {
        interactionIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactionIcon.SetActive(false);
    }

    // Checks if player can interact
    void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, _boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D raycast in hits)
            {
                if (raycast.transform.GetComponent<Interactions>())
                {
                    raycast.transform.GetComponent<Interactions>().Interact();
                    return;
                }
            }
        }
    }

    // Activates interaction according to input
    void Interaction()
    {
        if (interactAction.triggered)
        {
            CheckInteraction();
        }
    }
     private void SpawnDashParticles()
    {
        dashParticlesInstance = Instantiate(dashParticles, transform.position, Quaternion.identity);
    }
}
