using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Input
    public InputAction moveAction; // Input action for movement
    public InputAction attackAction; // Input action for attack

    // Movement
    public float moveSpeed = 5f; // Speed of the player

    // Animations
    public Animator animator; // Animator component

    // Stats
    public float maxHealth = 100;
    [HideInInspector] public float playerHealth;
    public float playerDamage = 5;
    TextMeshPro textHealth;

    // Stamina
    public float staminaTime = 3f;
    float staminaCooldown = 0f;
    bool hasStamina = false;
    TextMeshPro textStamina;
    [HideInInspector] public bool hasAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the move action to start receiving input
        attackAction.Enable(); // Enable the attack action to start receiving input

        animator = GetComponent<Animator>(); // Get the Animator component attached to the player

        textStamina = GetComponentsInChildren<TextMeshPro>().FirstOrDefault(t => t.name == "stamina"); 
        textHealth = GetComponentsInChildren<TextMeshPro>().FirstOrDefault(t => t.name == "playerHealth");

        playerHealth = maxHealth; // sets playerhealth to maximum\

        textHealth.text = "Health: " + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call the MovePlayer method to handle movement
        AnimatePlayer(); // Call the AnimatePlayer method to handle animation

        Health();

        StaminaCooldown();
    }

    // player movement
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

    // player animations
    // checks movement and animates accordingly
    void AnimatePlayer()
    {
        if (moveAction.ReadValue<Vector2>().x > 0) 
        {
            animator.SetBool("isRight", true); 
        }
        else
        {
            animator.SetBool("isRight", false); 
        }
        if (moveAction.ReadValue<Vector2>().x < 0) 
        {
            animator.SetBool("isLeft", true); 
        }
        else
        {
            animator.SetBool("isLeft", false); 
        }
        if (moveAction.ReadValue<Vector2>().y > 0) 
        {
            animator.SetBool("isUp", true); 
        }
        else
        {
            animator.SetBool("isUp", false); 
        }
        if (moveAction.ReadValue<Vector2>().y < 0) 
        {
            animator.SetBool("isDown", true); 
        }
        else
        {
            animator.SetBool("isDown", false); 
        }
    }

    // Stamina cooldown and check
    void StaminaCooldown()
    {
        if ((staminaCooldown <= 0f) && (hasStamina == false))
        {
            hasStamina = true;
            hasAttack = true;
            staminaCooldown = staminaTime;
        }
        else
        {
            staminaCooldown -= Time.deltaTime;
            
            if (staminaCooldown < 0f)
            {
                staminaCooldown = 0f;
            }
        }

        if (hasStamina) // displays stamina when cooldown is active
        {
            textStamina.enabled = false;
        }
        else
        {
            textStamina.enabled = true;
            textStamina.text = "Stamina: " + Mathf.CeilToInt(staminaCooldown);
        }

        if (attackAction.IsPressed() && hasStamina)
        {
            hasStamina = false;
        }
    }

    // Player attacking
    public float Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 5f); // Adjust radius as needed

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                if (attackAction.IsPressed() && hasAttack)
                {
                    hasStamina = false;
                    hasAttack = false;
                    return playerDamage;
                }
            }
        }

        return 0;
    }

    // Player health display and check
    void Health()
    {
        textHealth.text = "Health: " + playerHealth;

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        RawImage full = GameObject.Find("fullHealth").GetComponent<RawImage>();
        RawImage three = GameObject.Find("threeHealth").GetComponent<RawImage>();
        RawImage half = GameObject.Find("halfHealth").GetComponent<RawImage>();
        RawImage quarter = GameObject.Find("quarterHealth").GetComponent<RawImage>();
        RawImage zero = GameObject.Find("zeroHealth").GetComponent<RawImage>();

        if (playerHealth == maxHealth)
        {
            full.enabled = true;
            three.enabled = false;
            half.enabled = false;
            quarter.enabled = false;
            zero.enabled = false;
        }
        
        if (playerHealth < maxHealth && playerHealth > (maxHealth/2))
        {
            full.enabled = false;
            three.enabled = true;
            half.enabled = false;
            quarter.enabled = false;
            zero.enabled = false;
        }
        
        if (playerHealth == (maxHealth/2))
        {
            full.enabled = false;
            three.enabled = false;
            half.enabled = true;
            quarter.enabled = false;
            zero.enabled = false;
        }
        
        if (playerHealth < (maxHealth/2))
        {
            full.enabled = false;
            three.enabled = false;
            half.enabled = false;
            quarter.enabled = true;
            zero.enabled = false;
        }

        if (playerHealth <= 0)
        {
            full.enabled = false;
            three.enabled = false;
            half.enabled = false;
            quarter.enabled = false;
            zero.enabled = true;

            Destroy(gameObject);
            print("Game Over");
        }
    }
}
