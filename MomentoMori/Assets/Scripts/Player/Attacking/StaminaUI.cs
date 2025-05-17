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
    public Image staminaBar;
    
    [SerializeField] private float stamina, maxStamina;
    [SerializeField] private float chargeRate;
    private bool hasStamina = true;

    // Attacking
    [SerializeField] private float attackCost;

    private Coroutine recharge;

    public PlayerAttack player;

    void Start()
    {
        stamina = maxStamina; // Sets stamina to full
    }

    void Update()
    { 
        player.AttackTimer(); // Initiates time and check for each attack

        if (player.attackAction.triggered && hasStamina == true) // Checks if attack button is pressed and if player has stamina
        {
            player.OnAttack(); // Activates attack

            stamina -= attackCost; // Attacks use stamina

            if (recharge != null) // Checks and initiates cooldown before recharging stamina
            {
                StopCoroutine(recharge); 
            }

            recharge = StartCoroutine(RechargeStamina()); // Stamina recharges
        }

        if (stamina < 0) // Ensures stamina not below 0
        {
            stamina = 0;
        }

        if (stamina > maxStamina) // Ensures stamina not above max
        {
            stamina = maxStamina;
        }

        // Stamina checks for cost of attacks and if player has stamina to attack
        if (stamina < attackCost)
        {
            hasStamina = false;
        }

        if (stamina >= attackCost)
        {
            hasStamina = true;
        }

        staminaBar.fillAmount = stamina/maxStamina; // Stamina bar fills
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
