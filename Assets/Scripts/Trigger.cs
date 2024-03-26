using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public LogicScript logic;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
    }


    void Start()
    {
        logic= GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

   
    void Update()
    {

    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.PlaySFX(audioManager.Point);
        if(collision.gameObject.layer == 3)
        logic.addScore();
    }
}
