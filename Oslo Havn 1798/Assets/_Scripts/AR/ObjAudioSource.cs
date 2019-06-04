using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAudioSource : MonoBehaviour
{
    /// <summary>
    /// Inneholder lydfiler og funksjoner til de. Blir referert til direkte i 
    ///  animasjonslipp via Events. 
    ///  
    /// Har noen manuelle knapper for å tvinge inn visse states i Audio Animatoren, 
    ///   men dette er kun for testing purposes. 
    /// </summary>
    
    
    //  Lydfiler
    public AudioClip S1;
    public AudioClip S2;
    public AudioClip S3;
    public AudioClip S4;
    public AudioClip S5;
    //public AudioClip Annoyed1;
    //public AudioClip Annoyed2;
    public AudioClip[] Annoyed;
    public AudioClip Goodbye;
    public AudioClip[] Continue;
    public AudioClip Finished;
    public AudioClip Idle;


    private Animator anim;
    private AudioSource Lyd;
    
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Lyd = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Starter dialogen
        if (Input.GetKeyDown("q")){
            //Debug.Log("QQ");
            anim.SetTrigger("T_Start-Talking");
        }

        // Gjør Meyer irritert
        if (Input.GetKeyDown("w"))
        {
            anim.SetTrigger("T_Annoyed");
        }
        // Går fra irritert til å fortsette å prate. Starter der han slutter
        if (Input.GetKeyDown("e"))
        {
            anim.SetTrigger("T_Continue");
        }

        // Goodbye. Går fra brukeren og restarter hele prosessen
        if (Input.GetKeyDown("r"))
        {
            anim.SetTrigger("T_Goodbye");
        }

        
    }

    public void AuS1()
    {
        Lyd.clip = S1;
        Lyd.Play();

    }
    public void AuS2()
    {
        Lyd.clip = S2;
        Lyd.Play();
    }
    public void AuS3()
    {
        Lyd.clip = S3;
        Lyd.Play();
    }
    public void AuS4()
    {
        Lyd.clip = S4;
        Lyd.Play();
    }
    public void AuS5()
    {
        Lyd.clip = S5;
        Lyd.Play();
    }
    public void AuAnnoyed()
    {
        //Lyd.clip = Annoyed;
        Lyd.clip = Annoyed[Random.Range(0, Annoyed.Length)];
        Lyd.Play();
    }
    public void AuGoodbye()
    {
        Lyd.clip = Goodbye;
        Lyd.Play();
    }
    public void AuContinue()
    {
        //Lyd.clip = Continue;
        Lyd.clip = Continue[Random.Range(0, Continue.Length)];
        Lyd.Play();
    }
    public void AuFinished()
    {
        Lyd.clip = Finished;
        Lyd.Play();
    }
    public void AuIdle()
    {
        Lyd.clip = Idle;
        Lyd.Play();
    }
    public void Empty()
    {
        Lyd.Stop();
    }
}
