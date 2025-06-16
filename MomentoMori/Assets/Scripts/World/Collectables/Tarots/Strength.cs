using UnityEngine;

public class Strength : Item
{
    public int attackGain = 5;

    public override void UseItem()
    {
        attack.AddAttack(attackGain);

        base.UseItem();
    }
}
