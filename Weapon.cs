public class Weapon : InventoryItem
{
    public Weapon(int attackModifier, Animation animation) 
        : base(attackModifier, animation)
    {
    }

    public override int getAttackModifier()
    {
        return attackModifier;
    }
}