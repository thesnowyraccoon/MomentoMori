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
    public InputAction interactAction; // Input action for interactions

    // Movement
    public float moveSpeed = 5f; // Speed of the player

    // Animations
    public Animator animator; // Animator component

    // Stats
    public float maxHealth = 100;
    [HideInInspector] public float playerHealth;
    public float playerDamage = 5;
    private TextMeshPro _textHealth;

    // Stamina
    public float staminaTime = 3f;
    private float _staminaCooldown = 0f;
    private bool _hasStamina = false;
    private TextMeshPro _textStamina;
    [HideInInspector] public bool hasAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Enable the move action to start receiving input
        attackAction.Enable(); // Enable the attack action to start receiving input
        interactAction.Enable();

        animator = GetComponent<Animator>(); // Get the Animator component attached to the player

        _textStamina = GetComponentsInChildren<TextMeshPro>().FirstOrDefault(t => t.name == "stamina"); 
        _textHealth = GetComponentsInChildren<TextMeshPro>().FirstOrDefault(t => t.name == "playerHealth");

        playerHealth = maxHealth; // sets playerhealth to maximum\

        _textHealth.text = "Health: " + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // Call to handle movement and animation

        Interaction(); // Call to check if interacting

        Health(); // Call to check health, and to set and animate accordingly

        StaminaCooldown(); // Cooldown for attacking
    }

    // player movement
    void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero; // Initialize move direction

        bool isUp = false, isLeft = false, isDown = false, isRight = false; // Consistently sets movement animation false when not moving
        bool isIdle = true; // Sets idle animation true when not moving

        // Checks for WASD movement in 4 directions and animates accordingly
        if (moveAction.ReadValue<Vector2>().x > 0)
        {
            moveDirection.x += 1;
            isRight = true;
            isIdle = false;
        }
        else if (moveAction.ReadValue<Vector2>().x < 0) 
        {
            moveDirection.x -= 1;
            isLeft = true;
            isIdle = false;
        }
        else if (moveAction.ReadValue<Vector2>().y > 0) 
        {
            moveDirection.y += 1;
            isUp = true;
            isIdle = false;
        }
        else if (moveAction.ReadValue<Vector2>().y < 0) 
        {
            moveDirection.y -= 1;
            isDown = true;
            isIdle = false;
        }
    
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime; // Move the player based on input

        animator.SetBool("isRight", isRight);
        animator.SetBool("isLeft", isLeft);
        animator.SetBool("isUp", isUp);
        animator.SetBool("isDown", isDown);
        animator.SetBool("isIdle", isIdle);
    }

    // Stamina cooldown and check
    void StaminaCooldown()
    {
        if ((_staminaCooldown <= 0f) && (_hasStamina == false))
        {
            _hasStamina = true;
            hasAttack = true;
            _staminaCooldown = staminaTime;
        }
        else
        {
            _staminaCooldown -= Time.deltaTime;
            
            if (_staminaCooldown < 0f)
            {
                _staminaCooldown = 0f;
            }
        }

        if (_hasStamina) // displays stamina when cooldown is active
        {
            _textStamina.enabled = false;
        }
        else
        {
            _textStamina.enabled = true;
            _textStamina.text = "Stamina: " + Mathf.CeilToInt(_staminaCooldown);
        }

        if (attackAction.IsPressed() && _hasStamina)
        {
            _hasStamina = false;
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
                    _hasStamina = false;
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
        _textHealth.text = "Health: " + playerHealth;

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        RawImage full = GameObject.Find("fullHealth").GetComponent<RawImage>();
        RawImage three = GameObject.Find("threeHealth").GetComponent<RawImage>();
        RawImage half = GameObject.Find("halfHealth").GetComponent<RawImage>();
        RawImage quarter = GameObject.Find("quarterHealth").GetComponent<RawImage>();
        RawImage zero = GameObject.Find("zeroHealth").GetComponent<RawImage>();

        TextMeshProUGUI gameOver = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI overText = GameObject.Find("overText").GetComponent<TextMeshProUGUI>();
        Image overButton = GameObject.Find("overButton").GetComponent<Image>();

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

            gameOver.enabled = true;
            overButton.enabled = true;
            overText.enabled = true;
        }
    }

    void Interaction()
    {
        if (interactAction.IsPressed())
        {
            bool interactable = GameObject.Find("Interactable").GetComponent<Interactable>().interactable;
            
            if (interactable == true)
            {
                Canvas tarot = GameObject.Find("Tarot UI").GetComponent<Canvas>();
                tarot.enabled = true;
            }
        }
    }
}
