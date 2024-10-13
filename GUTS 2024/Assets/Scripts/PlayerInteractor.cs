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
        if (collision.gameObject.CompareTag("Teleport"))
        {
            if (transform.position == (-27,88266937,0)){
                transform.position = new Vector3(-9.7, -27.3, 0);
            };
            else if (transform.position == (24.2,30.8,0)){
                transform.position = new Vector3(-9.7,-27.3,0);
            }
            else if (transform.position == (-9.7,-27.3,0)){
                transform.position = new Vector3(-27,8266937,0);
            }
            else if (transform.position == (-88,-44,0)){
                transform.position = new Vector3(11,110.6,0);
            }
            else if (transform.position == (-33.8,-53.5,0)){
                transform.position = new Vector3(65.2,-51.8,0);            
            }
            else if (transform.position == (11,-110.6,0)){
                transform.position = new Vector3(-33.8,-53,5,0);
            }
            else if (transform.position == (65.2,-51.8,0)){
                transform.position = new Vector3(11,-110.6,0);
            }
            Debug.Log("Teleport");
        }
    }

    public void Death()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
}
