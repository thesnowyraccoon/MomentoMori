using UnityEngine;

public class WheelOfFortune : Item
{
    bool tarotActive = false;

    public int speedGain = 5;
    public float dashGain = 300;
    public PlayerController.MaximumHealth maximumHealth = PlayerController.MaximumHealth.Thirty;
    public int damageGain = 4;
    public float staminaGain = 50;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            int fortune = Random.Range(1, 6);

            if (fortune == 1)
            {
                player.AddSpeed(speedGain);
            }
            else if (fortune == 2)
            {
                player.DashGain(dashGain);
            }
            else if (fortune == 3)
            {
                player.maximumHealth = maximumHealth;
            }
            else if (fortune == 4)
            {
                attack.AddAttack(damageGain);
            }
            else if (fortune == 5)
            {
                stamina.StaminaIncrease(staminaGain);
            }

            tarotActive = true;
        }
    }
}
