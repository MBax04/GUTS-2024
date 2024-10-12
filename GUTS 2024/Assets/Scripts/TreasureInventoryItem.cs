using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasureInventoryItem
{
    public string treasureTypeName;
    public int treasureTypeQuantity = 0;
    public int maximumQuantity; // (in level)
    public TMP_Text textObj;

    public TreasureInventoryItem(string treasureTypeName, int maximumQuantity, TMP_Text textObj) {
        this.treasureTypeName = treasureTypeName;
        this.maximumQuantity = maximumQuantity;
        this.textObj = textObj;

        updateText();
    }

    public void updateText() {
        textObj.SetText(treasureTypeName + " (" + treasureTypeQuantity.ToString() + "/" + maximumQuantity.ToString() + ")");
    }

    public void setQuantity(int quantity) {
        this.treasureTypeQuantity = quantity;
        updateText();
    }
}
