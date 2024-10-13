using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Attributes")]
    private Rigidbody2D rb;

    private string ObjectName;

    private GameObject treasureInventory;
    private TreasureInventory treasureInventoryScript;

    public bool canGoToNextLevel = true;

    //public PlayerInteractor(bool canGoToNextLevel){
       // this.canGoToNextLevel = canGoToNextLevel;
    //}


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        treasureInventory = GameObject.FindGameObjectWithTag("Treasure Inventory Canvas");
        treasureInventoryScript = treasureInventory.GetComponent<TreasureInventory>();
        //canGoToNextLevel = false;

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
        if (collision.gameObject.CompareTag("Torch"))
        {
            collision.gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerTorch>().torchRecharge(60);
        }
        if (collision.gameObject.CompareTag("Door")){
            //if(canGoToNextLevel){
                //Debug.Log("door shoudld take player to next level yay");
            //}
            //else{
                //Debug.Log("door is lock as player has not met reasure quota");
            //}
            Debug.Log("door shoudld take player to next level yay");
            SceneManager.LoadScene(2);
        }
    }

    public void setCanGoToNextLevel(){
        this.canGoToNextLevel = true;
    }
    public bool getCanGoToNextLevel(){
        return canGoToNextLevel;
    }

    public void Death()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
}
