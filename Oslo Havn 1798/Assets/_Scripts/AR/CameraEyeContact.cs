using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEyeContact : MonoBehaviour
{
    /// <summary>
    /// Bruker collider objektet under AR camera for å se om den kolliderer
    ///  med en trigger under P_Meyer. Referer til ulike bools i P_Meyer
    ///  animator basert på boolen B_Angry i dette scriptet. 
    /// </summary>

    private GameObject Meyer;
    private Animator MeyerAnim;

    private GameObject AudiSource;
    private Animator AudiAnim;

    public bool B_Angry = false;

    public void Start()
    {
        Meyer = GameObject.FindGameObjectWithTag("P_Meyer");
        MeyerAnim = Meyer.GetComponent<Animator>();

        AudiSource = GameObject.FindGameObjectWithTag("SourceAudio");
        AudiAnim = AudiSource.GetComponent<Animator>();
    }

    public void Update()
    {
        if (B_Angry == true)
        {
            MeyerAnim.SetBool("B_Angry", true);
            MeyerAnim.SetBool("B_Happy", false);

            //AudiAnim.SetTrigger("T_Annoyed");
        }
        if (B_Angry == false)
        {
            MeyerAnim.SetBool("B_Angry", false);
            MeyerAnim.SetBool("B_Happy", true);

            //AudiAnim.SetTrigger("T_Continue");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EyeContact" && B_Angry == true)
        {
            //Debug.Log("Happy Again");
            //MeyerAnim.SetBool("T_Happy", true);

            ///     Audio trigger
            //AudiAnim.SetTrigger("T_Continue");
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "EyeContact")
        {
            //Debug.Log("Lookin'");
            B_Angry = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EyeContact")
        {
            //Debug.Log("Excuse me!");
            B_Angry = true;
            //MeyerAnim.SetBool("T_Angry", true);

            ///     Audio trigger
            //AudiAnim.SetTrigger("T_Annoyed");
        }
    }
}
