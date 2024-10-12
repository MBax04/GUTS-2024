using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint=0;
    }

    void FixedUpdate()
    {
   
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed* Time.deltaTime);
         if (transform.position == patrolPoints[targetPoint].position){
            increaseTargetInt();
        }
    
    }

    void increaseTargetInt(){
        targetPoint++;
        if (targetPoint>=patrolPoints.Length){
            targetPoint = 0;
        }
    }
}
