public class Inventory
{
    protected List<InventoryItem> items;
    public Inventory()
    {
        items = new List<InventoryItem>();
    }

    public List<InventoryItem> getItems(){
        return items;
    }

    public void addItem(InventoryItem item){
        items.Add(item);
    }

    public void removeItem(InventoryItem item){
        items.Remove(item);
    }
}