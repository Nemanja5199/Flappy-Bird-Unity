using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovment : MonoBehaviour
{


    public float moveSpeed=5;
    public float DeadZone = -30;



    void Start()
    {
        
    }

    void deletePipe()
    {
        Destroy(gameObject);
    }

    public void stopPipes()
    {
        moveSpeed = 0;
    }

   
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < DeadZone)
        {
            deletePipe();
        }
    }
}
