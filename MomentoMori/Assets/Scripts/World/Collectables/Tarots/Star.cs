using UnityEngine;

public class Star : Item
{
    bool tarotActive = false;

    public PlayerController.MaximumHealth maximumHealth = PlayerController.MaximumHealth.Thirty;
    public int healthGain = 30;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            player.maximumHealth = maximumHealth;
            player.HealthGain(healthGain);

            tarotActive = true;
        }
    }
}
