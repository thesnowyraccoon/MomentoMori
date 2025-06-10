using UnityEngine;

public class Chariot : Item
{
    bool tarotActive = false;

    public int speedGain = 5;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            player.AddSpeed(speedGain);

            tarotActive = true;
        }
    }
}
