using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeyerAudiotriggers : MonoBehaviour
{
    /// <summary>
    /// Script på P-Meyer som skal inneholde enkle funksjoner som styrer AudioSource
    ///  animator. Funksjonene spilles av som events på P-Meyer sine animasjoner. 
    /// </summary>

    private Animator AudiAnim;
    private GameObject AudiObj;

    public void Start()
    {
        AudiObj = GameObject.FindGameObjectWithTag("SourceAudio");
        AudiAnim = AudiObj.GetComponent<Animator>();
    }

    public void TAnnoyed()
    {
        AudiAnim.SetTrigger("T_Annoyed");
    }
    public void TContinue()
    {
        AudiAnim.SetTrigger("T_Continue");
    }
    public void TGoodbye()
    {
        AudiAnim.SetTrigger("T_Goodbye");
    }
}
