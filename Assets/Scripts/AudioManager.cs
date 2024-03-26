using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip Die;
    public AudioClip Jump;
    public AudioClip Point;
    public AudioClip Hit;

    public float Bvolume= 0.6f;
    public float SFXvolume = 0.6f;



    private void Start()
    {
        musicSource.volume = Bvolume;
        
        musicSource.clip = background;

        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlaySFX(AudioClip clip)
        
    {
        SFXSource.volume = SFXvolume;
        SFXSource.PlayOneShot(clip);
    }

    public void Stop() 
    {

     musicSource.Stop();

    }
}

