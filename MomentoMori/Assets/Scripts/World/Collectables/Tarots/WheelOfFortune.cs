using UnityEngine;

public class WheelOfFortune : Item
{
    public int speedGain = 10;
    public float dashGain = 5;
    public PlayerController.MaximumHealth maximumHealth = PlayerController.MaximumHealth.Fifty;
    public int damageGain = 15;
    public float staminaGain = 17;

    public override void UseItem()
    {
        int fortune = Random.Range(0, 6);

        if (fortune == 0)
        {
            Debug.Log("Loser :P");
        }
        else if (fortune == 1)
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

        base.UseItem();
    }
}
