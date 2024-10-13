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
    private Collider2D[] EnemyColliders;
    public float attackRange;
    public SpriteRenderer spriteRenderer;
    private bool canAttack = true;

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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && canAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        spriteRenderer.enabled = true;
        canAttack = false;
        EnemyColliders = Physics2D.OverlapCircleAll(this.transform.position, attackRange);

        for (int i = 0; i < EnemyColliders.Length; i++)
        {
            if (EnemyColliders[i].CompareTag("Enemy"))
            {
                EnemyColliders[i].gameObject.SetActive(false);
            }
        }
        StartCoroutine(AttackWait());


        IEnumerator AttackWait()
        {
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            canAttack = true;
        }
    }

    public void updateHearts() 
    {
        for (int i=0; i < hearts.Length; i++) {
            RawImage heart = hearts[i];
            if (i < lives) heart.texture = Resources.Load<Texture>("UI Assets/Heart");
            else heart.texture = Resources.Load<Texture>("UI Assets/BrokenHeart");
        }
    }

    public void LoseLive()
    {   
        if (lives > 0) lives--;
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
        updateHearts();
    }

    public void Die()
    {
        this.transform.position = new Vector3(0,0,0);
    }
}
