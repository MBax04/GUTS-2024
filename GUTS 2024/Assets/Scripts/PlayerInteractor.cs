using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Attributes")]
    private Rigidbody2D rb;

    private string ObjectName;

    private GameObject treasureInventory;
    private TreasureInventory treasureInventoryScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        treasureInventory = GameObject.FindGameObjectWithTag("Treasure Inventory Canvas");
        treasureInventoryScript = treasureInventory.GetComponent<TreasureInventory>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pit"))
        {
            Death();
        }
        if (collision.gameObject.CompareTag("Treasure Chest"))
        {
            treasureInventoryScript.UpdateList("TreasureChest");
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            ObjectName = collision.gameObject.name;
            treasureInventoryScript.UpdateList(ObjectName);
        }
        if (collision.gameObject.CompareTag("Health Potion"))
        {
            Debug.Log("Health Potion");
        }
    }






    public void Death()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
}
