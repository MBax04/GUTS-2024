public class Treasure : MapEntity{
    public string treasureTypeName;
    public int treasureTypeQuantity;
    public bool isCollected;

    public Treasure(string treasureTypeName, int treasureTypeQuantity)
    {
        this.treasureTypeName = treasureTypeName;
        this.treasureTypeQuantity = treasureTypeQuantity;
        this.isCollected = false;
    }

    public void setCollected(bool value, Player player)
    {
        this.isCollected = value;
        if (isCollected)
        {
            this.isVisibleOnMap = false;
            if (inventoryItem != null){
                // add to players list of collected items 
                player.treasure.add(this);
            }

        }
    }

    public string getTreasureTypeName()
    {
        return treasureTypeName;
    }

    public int getTreasureTypeQuantity()
    {
        return treasureTypeQuantity;
    }

    public bool getIsCollected()
    {
        return isCollected;
    }
}