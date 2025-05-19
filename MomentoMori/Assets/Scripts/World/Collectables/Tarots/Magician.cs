using UnityEngine;

public class Magician : Item
{
    bool tarotActive = false;

    public int staminaGain = 10;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            stamina.ChargeGain(staminaGain);

            tarotActive = true;
        }
    }
}
