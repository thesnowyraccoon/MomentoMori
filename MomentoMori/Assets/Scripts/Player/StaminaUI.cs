using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Title: Stamina Bar in Unity Tutorial
// Author: Gatsby
// Date: July 14 2023
// Code version: Unknown
// Availability: https://youtu.be/ju1dfCpDoF8?si=q4vvotPuifmOEMJT

public class StaminaUI : MonoBehaviour
{
    // Stamina 
    [Header("UI")]
    public Image staminaBar;

    [Header("Stamina")]
    [SerializeField] private float stamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float chargeRate;
    private bool hasStamina = true;

    // Attacking
    [Header("Attack")]
    [SerializeField] private float attackCost;

    // Dashing
    [Header("Dash")]
    [SerializeField] private float dashCost;

    private Coroutine recharge;

    [Header("Player")]
    public PlayerController playerController;
    public PlayerAttack playerAttack;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();

        stamina = maxStamina; // Sets stamina to full

        if (staminaBar == null)
        {
            Debug.LogWarning("Stamina Bar not found!");
        }
    }

    void Update()
    {
        Attacking();
        Dashing();
        Stamina();
    }

    public void ChargeGain(int charge)
    {
        chargeRate += charge;
    }

    public void StaminaIncrease(float increase)
    {
        maxStamina += increase;
    }

    void Attacking()
    {
        playerAttack.AttackTimer(); // Initiates time and check for each attack

        if (playerAttack.attackAction.triggered && hasStamina == true) // Checks if attack button is pressed and if player has stamina
        {
            playerAttack.OnAttack(); // Activates attack

            stamina -= attackCost; // Attacks use stamina

            if (recharge != null) // Checks and initiates cooldown before recharging stamina
            {
                StopCoroutine(recharge); 
            }

            recharge = StartCoroutine(RechargeStamina()); // Stamina recharges
        }
    }

    void Dashing()
    {
        if (playerController.dashAction.triggered && hasStamina == true) // Checks if attack button is pressed and if player has stamina
        {
            playerController.Dash();

            stamina -= dashCost; // Attacks use stamina

            if (recharge != null) // Checks and initiates cooldown before recharging stamina
            {
                StopCoroutine(recharge); 
            }

            recharge = StartCoroutine(RechargeStamina()); // Stamina recharges
        }
    }

    void Stamina()
    {
        if (stamina < 0) // Ensures stamina not below 0
        {
            stamina = 0;
        }

        if (stamina > maxStamina) // Ensures stamina not above max
        {
            stamina = maxStamina;
        }

        // Stamina checks for cost of attacks and if player has stamina to attack
        if (stamina < attackCost || stamina < dashCost)
        {
            hasStamina = false;
        }

        if (stamina >= attackCost || stamina >= dashCost)
        {
            hasStamina = true;
        }

        if (staminaBar != null)
        {
            staminaBar.fillAmount = stamina/maxStamina; // Stamina bar fills
        }
    }

    private IEnumerator RechargeStamina() // Stamina recharges after a short duration after attacking
    {
        yield return new WaitForSeconds(1f);

        while (stamina < maxStamina)
        {
            stamina += chargeRate / 10f;

            yield return new WaitForSeconds(.1f);
        }
    }
}
