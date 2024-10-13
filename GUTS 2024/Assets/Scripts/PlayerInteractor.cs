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
            this.GetComponent<PlayerCombat>().Die();
        }
        if (collision.gameObject.CompareTag("Treasure Chest"))
        {
            collision.gameObject.SetActive(false);
            treasureInventoryScript.UpdateList("TreasureChest");
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            ObjectName = collision.gameObject.name;
            collision.gameObject.SetActive(false);
            treasureInventoryScript.UpdateList(ObjectName.Split(" ")[0]);
        }
        if (collision.gameObject.CompareTag("Health Potion"))
        {
            collision.gameObject.SetActive(false);
            this.GetComponent<PlayerCombat>().Heal();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyPatrol>().setHuntingPlayer(false);
            this.GetComponent<PlayerCombat>().LoseLive();
        }
    }
}
