using UnityEngine;

public class Emperor : Item
{
    bool tarotActive = false;

    public override void UseItem()
    {
        if (tarotActive == false)
        {
            

            tarotActive = true;
        }
    }
}
