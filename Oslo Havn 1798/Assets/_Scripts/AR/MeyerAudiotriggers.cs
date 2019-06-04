using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeyerAudiotriggers : MonoBehaviour
{
    /// <summary>
    /// Script på P-Meyer som skal inneholde enkle funksjoner som styrer AudioSource
    ///  animator. Funksjonene spilles av som events på P-Meyer sine animasjoner. 
    /// Gjør at "lipsync" animasjonen spiller samtidig som lydfilene. 
    ///  Referer til bools i AudioSource og matcher de med boolsene i animator
    ///  layeret "Jaw". 
    /// </summary>

    private Animator AudiAnim;
    private GameObject AudiObj;

    private Animator anim;

    public void Start()
    {
        AudiObj = GameObject.FindGameObjectWithTag("SourceAudio");
        AudiAnim = AudiObj.GetComponent<Animator>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void TAnnoyed()
    {
        AudiAnim.SetTrigger("T_Annoyed");
        anim.SetTrigger("Jaw_T_Annoyed");
    }
    public void TContinue()
    {
        AudiAnim.SetTrigger("T_Continue");
        anim.SetTrigger("Jaw_T_Continue");
    }
    public void TGoodbye()
    {
        AudiAnim.SetTrigger("T_Goodbye");
        anim.SetTrigger("Jaw_T_Goodbye");
    }

    public void Update()
    {
        /// Matcher lipsync med 
        if(AudiAnim.GetBool("B_1") == true)
        {
            anim.SetBool("Jaw_B_1", true);
        }
        if (AudiAnim.GetBool("B_2") == true)
        {
            anim.SetBool("Jaw_B_2", true);
        }
        if (AudiAnim.GetBool("B_3") == true)
        {
            anim.SetBool("Jaw_B_3", true);
        }
        if (AudiAnim.GetBool("B_4") == true)
        {
            anim.SetBool("Jaw_B_4", true);
        }
        if (AudiAnim.GetBool("B_5") == true)
        {
            anim.SetBool("Jaw_B_5", true);
        }

    }
}
