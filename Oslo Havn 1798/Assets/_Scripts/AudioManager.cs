using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource music;

    public AudioSource spawnEffectSound;

    public AudioSource fisketorvetWelcomeVoice;


    // Use this for initialization
    void Start ()
    {
        music.Play();
        Invoke("SpawnEffectSound", 2f);
    }


    void SpawnEffectSound()
    {
        spawnEffectSound.Play();
    }

    public void FisketorvetVoiceOver()
    {
       music.volume = 0.2f;
       fisketorvetWelcomeVoice.Play();
    }
}
