using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public LogicScript logic;
    public PipeMovment pipe;
    public PipeSpawner pipeSpawn;
    public Rigidbody2D BirdRigidbody;
    public Collider2D BirdCollider;
    public float flap;
    public bool birdisAlive = true;
    public float tilt;
    private bool collisionOccurred = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipe = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeMovment>();
    }

    void Update()
    {
        float velocityY = BirdRigidbody.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && birdisAlive)
        {
            BirdRigidbody.velocity = Vector2.up * flap;
            audioManager.PlaySFX(audioManager.Jump);
        }

        // Tilt the bird based on velocity
        float tiltAngle = Mathf.Lerp(-tilt, tilt, Mathf.InverseLerp(-6, 6, velocityY ));
        Quaternion targetRotation = Quaternion.Euler(0, 0, tiltAngle);

        // Apply the tilt smoothly
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, tilt * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collisionOccurred)
        {
            audioManager.PlaySFX(audioManager.Hit);
            collisionOccurred = true;
        }
       
        
        logic.gameOver();
        birdisAlive = false;
        Destroy(pipeSpawn);
        PipeMovment[] pipes = FindObjectsOfType<PipeMovment>();
        foreach (PipeMovment pipe in pipes)
        {
            pipe.stopPipes();
        }
       




    }
}
