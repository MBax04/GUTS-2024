using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasureInventory : MonoBehaviour
{
    public Dictionary<String, TreasureInventoryItem> inventory = new Dictionary<String, TreasureInventoryItem>();

    public TMP_Text inventory1text;
    public TMP_Text inventory2text;
    public TMP_Text inventory3text;
    
    private TMP_Text[] inventoryTexts;

    public TMP_Text getNextInventoryTextObj() {
        return inventoryTexts[inventory.Count];
    }

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text[] _inventoryTexts = {inventory1text, inventory2text, inventory3text};
        inventoryTexts = _inventoryTexts;

        // Initalise treasure types each with 0 quantity collected
        inventory.Add("bones", new TreasureInventoryItem("Bones", 20, getNextInventoryTextObj()));
        inventory.Add("gold", new TreasureInventoryItem("Gold", 50, getNextInventoryTextObj()));
        inventory.Add("fossil", new TreasureInventoryItem("Fossil", 10, getNextInventoryTextObj()));
    
        // Test values
        inventory["bones"].setQuantity(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
