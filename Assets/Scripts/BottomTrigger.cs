using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;





public class BottomTrigger : MonoBehaviour
{

    public BirdScript Bird;
    public LogicScript logic;
    public PipeMovment pipe;
    public PipeSpawner pipeSpawn;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        Bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipe = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Bird")
        {

            audioManager.PlaySFX(audioManager.Die);
            logic.gameOver();
            Destroy(Bird.gameObject);
            Bird.birdisAlive = false;
            Destroy(pipeSpawn.gameObject);
            PipeMovment[] pipes = FindObjectsOfType<PipeMovment>();
            foreach (PipeMovment pipe in pipes)
            {
                pipe.stopPipes();
            }
        }

            
          
        
            
    }
}
