using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLive()
    {
        lives--;
        Debug.Log("Live Lost" + lives);
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Heal()
    {
        if (lives < 3)
        {
            lives++;
        }
        Debug.Log("Healed" + lives);
    }

    public void Die()
    {
        Debug.Log("Dead");
        this.transform.position = new Vector3(0,0,0);
    }
}
