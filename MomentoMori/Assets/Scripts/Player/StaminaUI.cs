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
    public Image staminaBar;
    public float stamina, maxStamina;
    private bool hasStamina = true;

    public float attackCost;
    public float chargeRate;

    private Coroutine recharge;

    public PlayerAttack player;

    // Update is called once per frame
    void Update()
    { 
        if (player.attackAction.triggered && hasStamina == true)
        {
            stamina -= attackCost;

            if (recharge != null)
            {
                StopCoroutine(recharge);
            }

            recharge = StartCoroutine(RechargeStamina());
        }

        if (stamina < 0)
        {
            stamina = 0;
        }

        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }

        if (stamina < attackCost)
        {
            hasStamina = false;
        }

        if (stamina >= attackCost)
        {
            hasStamina = true;
        }

        staminaBar.fillAmount = stamina/maxStamina;
    }

    public bool GetStamina()
    {
        return hasStamina;
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while (stamina < maxStamina)
        {
            stamina += chargeRate / 10f;

            yield return new WaitForSeconds(.1f);
        }
    }
}
