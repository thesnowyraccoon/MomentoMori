using UnityEngine;

public class Star : Item
{
    public PlayerController.MaximumHealth maximumHealth = PlayerController.MaximumHealth.Twenty;
    public int healthGain = 50;

    public override void UseItem()
    {
        player.maximumHealth = maximumHealth;
        player.HealthGain(healthGain);

        base.UseItem();
    }
}
