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
    private Vector3 tempVec;


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
        if (collision.gameObject.CompareTag("Teleport"))
        {
            if (transform.position == new Vector3(-27,88266937,0)){
                tempVec = new Vector3(-9, -27, 0);
                transform.position = tempVec;
            }
            else if (transform.position == new Vector3(24,30,0)){
                tempVec = new Vector3(-9, -27, 0);
                transform.position = tempVec;
            }
            else if (transform.position == new Vector3(-9,-27,0)){
                transform.position = new Vector3(-27,8266937,0);
            }
            else if (transform.position == new Vector3(-88,-44,0)){
                transform.position = new Vector3(11,110,0);
            }
            else if (transform.position == new Vector3(-33,-53,0)){
                transform.position = new Vector3(65,-51,0);            
            }
            else if (transform.position == new Vector3(11,-110,0)){
                transform.position = new Vector3(-33,-53,0);
            }
            else if (transform.position == new Vector3(65,-51,0)){
                transform.position = new Vector3(11,-110,0);
            }
            Debug.Log("Teleport");
        }
        if (collision.gameObject.CompareTag("Torch"))
        {
            collision.gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerTorch>().torchRecharge(60);
        }
    }

    public void Death()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
}
