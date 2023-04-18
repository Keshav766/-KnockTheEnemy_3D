using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   
    GameObject playerRef;
    Rigidbody enemyRb;

    public float enemySpeed = 5.0f;

    void Start()
    {
        playerRef = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        Vector3 lookDirection = (playerRef.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);
        if(transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}
