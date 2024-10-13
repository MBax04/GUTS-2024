using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Numerics;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint = 0;
    public float speed;
    public int count = 0;
    private bool huntingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = patrolPoints[0].transform.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 10 && huntingPlayer){
            Debug.Log("Player Found");
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed);

            if (Vector3.Distance(patrolPoints[targetPoint].position, transform.position) <= 0.2) {
                increaseTargetInt();
            }
        }
        
    }



    void increaseTargetInt(){
        huntingPlayer = true;
        targetPoint++;
        if (targetPoint==patrolPoints.Length){
            targetPoint = 0;
        }
    }

    public void setHuntingPlayer(bool newValue)
    {
        huntingPlayer = newValue;
    }
}