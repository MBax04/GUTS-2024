using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Attributes")]
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pit"))
        {
            Death();
        }
        if (collision.gameObject.CompareTag("Treasure Chest"))
        {
            Debug.Log("Treasure Chest");
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Gem");
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
