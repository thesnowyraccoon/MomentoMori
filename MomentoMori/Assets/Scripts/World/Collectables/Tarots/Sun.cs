using UnityEngine;

public class Sun : Item
{
    public int melatoninHealth = 20;

    public override void UseItem()
    {
        GameObject melatonin = GameObject.Find("melatonin");

        if (melatonin != null)
        {
            melatonin.GetComponent<Melatonin>().SetHealth(melatoninHealth);
        }
    }
}
