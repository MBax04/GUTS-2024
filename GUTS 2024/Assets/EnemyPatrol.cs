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
        count=0;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed* Time.deltaTime);
        count++;
        if (count == Vector3.Distance(patrolPoints[targetPoint].position, transform.position)){
            increaseTargetInt();
        }
    }

    
    //public static float Distance (System.Numerics.Vector3 value1, System.Numerics.Vector3 value2);

    void OnCollisionEnter(Collision collision){
        targetPoint++;
        if (targetPoint>=patrolPoints.Length){
            targetPoint = 0;
    }}

    void increaseTargetInt(){
        targetPoint++;
        if (targetPoint>=patrolPoints.Length){
            targetPoint = 0;
        }
    }
}
