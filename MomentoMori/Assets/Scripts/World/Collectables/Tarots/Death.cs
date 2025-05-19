using UnityEngine;

public class Death : Item
{
    public override void UseItem()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("SAM IS DEAD");
        }
    }
}
