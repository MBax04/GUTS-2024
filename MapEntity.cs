public abstract class MapEntity
{
    protected string name;
    protected Sprite sprite;
    protected int x;
    protected int y;
    protected InventoryItem inventoryItem = null;  // can only be collected if non-null
    protected bool isVisibleOnMap = true;  // true as default

    public MapEntity(string name, Sprite sprite, int x, int y)
    {
        this.name = name;
        this.sprite = sprite;
        this.x = x;
        this.y = y;
    }

    public string getName() 
    {
        return this.name;
    }

    public abstract int getX() 
    {
        return this.x;
    }

    public abstract int getY() 
    {
        return this.y;
    }
}