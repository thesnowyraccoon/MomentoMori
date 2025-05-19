using UnityEngine;

public class AceOfSwords : Item
{
    bool tarotActive = false;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            attack.attackAction.Enable();

            tarotActive = true;
        }
    }
}
