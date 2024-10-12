using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Numerics;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint=0;
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed* Time.deltaTime);
        if (Vector3.Distance(patrolPoints[targetPoint].position, transform.position)<=0.2){
            increaseTargetInt();
        }
    }



    void increaseTargetInt(){
        targetPoint++;
        if (targetPoint==patrolPoints.Length){
            targetPoint = 0;
        }
    }
}
