public abstract class InventoryItem
{
    protected string name;
    protected int id;
    protected Character owner;
    protected Sprite sprite;

    public InventoryItem(string name, int id, Character owner, Sprite sprite)
    {
        this.name = name;
        this.id = id;
        this.owner = owner;
        this.sprite = sprite;
    }

    public abstract string GetName();

    public abstract Character GetOwner();
}