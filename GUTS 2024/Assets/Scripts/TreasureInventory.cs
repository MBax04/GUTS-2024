using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasureInventory : MonoBehaviour
{
    public Dictionary<String, TreasureInventoryItem> inventory = new Dictionary<String, TreasureInventoryItem>();
    public int level = 1;
    public TMP_Text inventory1text;
    public TMP_Text inventory2text;
    public TMP_Text inventory3text;
    public TMP_Text inventory4text;

    private TMP_Text[] inventoryTexts;

    public TMP_Text getNextInventoryTextObj() {
        return inventoryTexts[inventory.Count];
    }

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text[] _inventoryTexts = {inventory1text, inventory2text, inventory3text, inventory4text};
        inventoryTexts = _inventoryTexts;

        // Initalise treasure types each with 0 quantity collected
        if (level == 1) {
            inventory.Add("TreasureChest", new TreasureInventoryItem("Treasure Chest", 5, getNextInventoryTextObj()));
            inventory.Add("OrangeGem", new TreasureInventoryItem("Orange Gem", 5, getNextInventoryTextObj()));
            inventory.Add("PurpleGem", new TreasureInventoryItem("Purple Gem", 5, getNextInventoryTextObj()));
            inventory.Add("RedGem", new TreasureInventoryItem("Red Gem", 5, getNextInventoryTextObj()));
        } else {
            inventory.Add("TreasureChest", new TreasureInventoryItem("Treasure Chest", 10, getNextInventoryTextObj()));
            inventory.Add("GreenGem", new TreasureInventoryItem("Green Gem", 1, getNextInventoryTextObj()));
            inventory.Add("BlueGem", new TreasureInventoryItem("Blue Gem", 50, getNextInventoryTextObj()));
            inventory.Add("RedGem", new TreasureInventoryItem("Red Gem", 10, getNextInventoryTextObj()));
        }
    }

    public void UpdateList(string objectName)
    {
        TreasureInventoryItem item = inventory[objectName];
        if (item.treasureTypeQuantity < item.maximumQuantity) {
            item.setQuantity(item.treasureTypeQuantity + 1);

            Task inventoryTask = GameObject.Find("TaskListCanvas").GetComponent<TaskList>().tasks[0];
        
            int inventoryMax = 0;
            int inventoryContents = 0;
            foreach ((String key, TreasureInventoryItem x) in inventory) {
                inventoryMax += x.maximumQuantity;
                inventoryContents += x.treasureTypeQuantity;
            }

            if (inventoryMax > 0)
            inventoryTask.setCompletedness((float) inventoryContents / (float) inventoryMax);
        }
    }
}
