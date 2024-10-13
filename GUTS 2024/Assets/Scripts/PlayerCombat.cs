using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    private int lives = 3;
    public RawImage heart1;
    public RawImage heart2;
    public RawImage heart3;
    private RawImage[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        RawImage[] _hearts = new RawImage[] {heart1, heart2, heart3};
        hearts = _hearts; 
        updateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHearts() 
    {
        for (int i=0; i < hearts.Length; i++) {
            RawImage heart = hearts[i];
            if (i <= lives) heart.texture = Resources.Load<Texture>("UI Assets/Heart");
            else heart.texture = Resources.Load<Texture>("UI Assets/BrokenHeart");
        }
    }

    public void LoseLive()
    {
        lives--;
        Debug.Log("Live Lost" + lives);
        if (lives <= 0)
        {
            Die();
        }
        updateHearts();
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
