﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniManagerScr : MonoBehaviour
{
    /// <summary>
    /// Script på [MiniManager]
    /// Skal styre når audioen skal automatisk spille av. 
    ///  Når meyer er utenfor [Master_OnCam] området så 
    ///  skal scriptet sørge for at han går tilbake inn igjen. 
    /// Bestemmer når [Master_OnCam] er active (Set.Active) 
    /// </summary>

    private GameObject MasterOnCam;
    private GameObject EyeContact;

    private GameObject MeyerObj;
    private Animator MeyerAnim;
    private MeyerOutTheDoor meyeroutthedoor;
    private Transform tranMeyer;
    private GameObject objPos2;
    private Transform tranPos2;

    private GameObject AudiObj;
    private Animator AudiAnim;
    

    public void Start()
    {
        MasterOnCam = GameObject.FindGameObjectWithTag("TAG_MasterPos-1");
        EyeContact = GameObject.FindGameObjectWithTag("EyeContact");
        MeyerObj = GameObject.FindGameObjectWithTag("P_Meyer");
        MeyerAnim = MeyerObj.GetComponent<Animator>();
        meyeroutthedoor = MeyerObj.GetComponent<MeyerOutTheDoor>();
        tranMeyer = MeyerObj.GetComponent<Transform>();

        objPos2 = GameObject.FindGameObjectWithTag("MeyerPos_2");
        tranPos2 = objPos2.GetComponent<Transform>();

        AudiObj = GameObject.FindGameObjectWithTag("SourceAudio");
        AudiAnim = AudiObj.GetComponent<Animator>();
        
    }

    public void AfterFaded()
    {
        tranMeyer.transform.position = tranPos2.transform.position; 
    }

    ///     Funksjoner som skrur [Master_OnCam] av og på. 
    ///         Brukes i Animatoren. 
    public void DisableMaster()
    {
        MasterOnCam.SetActive(false);
        EyeContact.SetActive(false);
        //Debug.Log("MasterDisabled(Inside)");
    }
    public void EnableMaster()
    {
        MasterOnCam.SetActive(true);
        EyeContact.SetActive(true);
        //Debug.Log("MasterEnabled(Outside)");
    }

    public void IsTalking()
    {
        AudiAnim.SetTrigger("T_Start-Talking");
        // Syncer lyd med lipsync
        //MeyerAnim.SetTrigger("Jaw_T_Start-Talking");
        MeyerAnim.SetBool("UB_isTalking", true);
        MeyerAnim.SetTrigger("Jaw_T_Start-Talking");
        //Debug.Log("Meyer is Talking");
    }
    public void UserLeaving()
    {
        //Debug.Log("User is leaving");
    }
    public void BackInside()
    {
        MeyerAnim.SetTrigger("T_CloseDoor"); 
        //Debug.Log("On the way back inside");
        meyeroutthedoor.B_MeyerOut = false;
        AudiAnim.SetTrigger("T_Goodbye");
    }
}
