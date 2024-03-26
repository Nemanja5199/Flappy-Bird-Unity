using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public GameObject Pipe;

    public float spawnRate = 2;
    private float timer = 0;
    public float hightOffset=10;
    
   
    void Start()
    {
        spwanPipe();
    }

    void spwanPipe()
    {
        float lowestPoint = transform.position.y - hightOffset;
        float highestPoint = transform.position.y + hightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }

    

    
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spwanPipe();
            timer = 0;
        }


        
    }
}
