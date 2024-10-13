using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Attributes")]
    private Rigidbody2D rb;
    private int targetIndex;
    public GameObject[] telePoints;

    private Vector3 teleportTarget;
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
        List<GameObject> telePoints = new List<GameObject>();
        teleportTarget = telePoints[0].transform.position;

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
        
        if (collision.gameObject.CompareTag("Teleport")){
            /*if(targetIndex < telePoints.Length){
                Physics.IgnoreCollision(telePoints[targetIndex+1].GetComponent<Collider>(), GetComponent<Collider>(), true);
            }
            else {
                Physics.IgnoreCollision(telePoints[0].GetComponent<Collider>(), GetComponent<Collider>(), true);
            }*/
            transform.position=teleportTarget;
            Debug.Log(teleportTarget);
            /*if(targetIndex < telePoints.Length){
                Physics.IgnoreCollision(telePoints[targetIndex+1].GetComponent<Collider>(), GetComponent<Collider>(), false);
            }
            else {
                Physics.IgnoreCollision(telePoints[0].GetComponent<Collider>(), GetComponent<Collider>(), false);
            }*/
            targetIndex++;
            teleportTarget = telePoints[targetIndex].transform.position;
            if (targetIndex >= telePoints.Length){
                targetIndex=0;
            }
            Debug.Log("Teleport");
        }}
    

    public void Death()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }

}