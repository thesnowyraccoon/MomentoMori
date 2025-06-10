using UnityEngine;

public class Strength : Item
{
    bool tarotActive = false;

    public int attackGain = 5;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            attack.AddAttack(attackGain);

            tarotActive = true;
        }
    }
}
