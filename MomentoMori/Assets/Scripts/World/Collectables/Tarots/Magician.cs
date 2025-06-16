public class Magician : Item
{
    public int staminaGain = 10;

    public override void UseItem()
    {
        stamina.ChargeGain(staminaGain);

        base.UseItem();
    }
}
