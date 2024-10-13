using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureInventory : MonoBehaviour
{
    public Dictionary<String, TreasureInventoryItem> inventory = new Dictionary<String, TreasureInventoryItem>();

    public TMP_Text inventory1text;
    public TMP_Text inventory2text;
    public TMP_Text inventory3text;
    public TMP_Text inventory4text;

    private TMP_Text[] inventoryTexts;

    private PlayerInteractor playerInteractor = new PlayerInteractor();

    public TMP_Text getNextInventoryTextObj() {
        return inventoryTexts[inventory.Count];
    }

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text[] _inventoryTexts = {inventory1text, inventory2text, inventory3text, inventory4text};
        inventoryTexts = _inventoryTexts;

        // Initalise treasure types each with 0 quantity collected
        inventory.Add("TreasureChest", new TreasureInventoryItem("Treasure Chest", 10, getNextInventoryTextObj()));
        inventory.Add("GreenGem", new TreasureInventoryItem("Green Gem", 1, getNextInventoryTextObj()));
        inventory.Add("BlueGem", new TreasureInventoryItem("Blue Gem", 50, getNextInventoryTextObj()));
        inventory.Add("RedGem", new TreasureInventoryItem("Red Gem", 10, getNextInventoryTextObj()));
        //playerInteractor.setCanGoToNextLevel();
        //playerInteractor.canGoToNextLevel = true;
        //Debug.Log("set to true");
    }

    public void UpdateList(string objectName)
    {
        inventory[objectName].setQuantity(inventory[objectName].treasureTypeQuantity + 1);
        if (inventory["TreasureChest"].treasureTypeQuantity==10){
            Debug.Log("can go to next level, max items found. Find door");
            playerInteractor.canGoToNextLevel = true;
            SceneManager.LoadScene(2);
        }
        //playerInteractor.setCanGoToNextLevel(true);
    
    }
}
