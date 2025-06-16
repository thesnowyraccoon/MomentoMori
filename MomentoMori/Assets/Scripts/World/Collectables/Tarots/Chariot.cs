using UnityEngine;

public class Chariot : Item
{
    public int speedGain = 5;

    public override void UseItem()
    {
        player.AddSpeed(speedGain);

        base.UseItem();
    }
}
