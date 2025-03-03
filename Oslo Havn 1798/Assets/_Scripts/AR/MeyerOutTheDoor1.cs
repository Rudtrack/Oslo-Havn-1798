﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class MeyerOutTheDoor : MonoBehaviour
{
    /// <summary>
    /// Styrer hvor Meyer skal stå i starten og hvor han skal gå til. 
    ///  Posisjonene han går imellom er Meyer_Position_1 og 2. 
    /// Trigger for når Meyer går ut av døra, styrer animatoren
    ///  angående herfra.
    ///  
    /// Skriv noe om hvordan roteringen for å få retta opp Meyer for 
    ///  walk animasjonen. 
    ///  
    /// Ligger på [P-Meyer]
    /// </summary>


    ///      Bool for å sjekke om Meyer skal ut eller ikke. True er ut
    public bool B_MeyerOut = false;


    ///      Bools for å sjekke om Meyer skal rotere seg eller ikke, og 
    ///       hvilken retning han skal rotere seg. 
    public bool B_MeyerAbleToTurn = false;
    public bool B_MeyerTurn = false;
    public bool B_NotMeyerTurn = true;
    public bool B_Meyer_R_Turn = false;
    public bool B_Meyer_L_Turn = false;


    ///      Brukes for å styre Meyer sine koordinasjoner
    private Transform TranMeyer;
    public Vector3 V3Meyer;


    ///      Animatoren til Meyer
    //public GameObject MeyerObj;
    private Animator MeyerAnim;


    ///      Koordinasjonene Meyer skal følge
    /// Koordinasjonene for ute av døra
    private GameObject ObjPosMeyer_1;
     //private Transform TranPosMeyer_1;
    private Vector3 V3PosMeyer_1;
    private GameObject ObjRotMeyer_1;
    private Vector3 V3RotMeyer_1;
    /// Koordinasjonene for inne i rommet
    private GameObject ObjPosMeyer_2;
     //private Transform TranPosMeyer_2;
    private Vector3 V3PosMeyer_2;
    private GameObject ObjRotMeyer_2;
    private Vector3 V3RotMeyer_2;

    public Transform TranRotMeyer1;
    public Transform TranRotMeyer2;

    ///     MiniManager
    private GameObject MiniManObj;
    private Animator MiniManAnim;


    /// Floats for lerping
    public float LerpTime = 0.1f;
    // Adjust the speed for the application.
    public float speed = 1.0f;


    void Start()
    {

        ObjPosMeyer_1 = GameObject.FindGameObjectWithTag("MeyerPos_1");
        ObjPosMeyer_2 = GameObject.FindGameObjectWithTag("MeyerPos_2");
        ObjRotMeyer_1 = GameObject.FindGameObjectWithTag("MeyerRot_1");
        ObjRotMeyer_2 = GameObject.FindGameObjectWithTag("MeyerRot_2");

        V3PosMeyer_1 = ObjPosMeyer_1.transform.position;
        V3PosMeyer_2 = ObjPosMeyer_2.transform.position;
        V3RotMeyer_1 = ObjRotMeyer_1.transform.eulerAngles;
        V3RotMeyer_2 = ObjRotMeyer_2.transform.eulerAngles;

        V3Meyer = transform.position;

        MeyerAnim = gameObject.GetComponent<Animator>();

        MiniManObj = GameObject.FindGameObjectWithTag("MiniManager");
        MiniManAnim = MiniManObj.GetComponent<Animator>();
        
    }

    
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move

        ///  Tester om Vector3/transform lerp fungerer ordentlig mellom de 2 posisjonene
        if (Input.GetKey("x"))
        {
            //B_MeyerOut = true;
            MeyerAnim.SetTrigger("T_OpenDoor");
        }
        if (Input.GetKey("c"))
        {
            B_MeyerOut = false;
            //BackInside();
            MeyerAnim.SetTrigger("T_CloseDoor");
        }


        // Hvis B_MeyerOut er false så skal Meyer lerpe tilbake til posisjon 2
        if (B_MeyerOut == false)
        {
            //V3Meyer = V3PosMeyer_2;
            transform.position = Vector3.MoveTowards(transform.position, V3PosMeyer_2, step);
            if (Vector3.Distance(transform.position, V3PosMeyer_2) < 0.09f)
            {
                //Debug.Log("Inside");
                MeyerAnim.SetBool("B_WalkBack", false);
                MeyerAnim.SetTrigger("T_CloseDoor");
            }
            else
            {
               // Debug.Log("Inbetween");
                MeyerAnim.SetBool("B_WalkBack", true);
            }
        }
        // Hvis B_MeyerOut er true, så lerper Meyer til posisjon 1
        if (B_MeyerOut == true)
        {
            //V3Meyer = V3PosMeyer_1;
            transform.position = Vector3.MoveTowards(transform.position, V3PosMeyer_1, step);
            if (Vector3.Distance(transform.position, V3PosMeyer_1) < 0.09f)
            {
                //Debug.Log("Outside");
                MeyerAnim.SetBool("B_Walk", false);
                //B_MeyerOut = false;
                MiniManAnim.SetTrigger("T_Outside");
            }
            else
            {
                //Debug.Log("Inbetween");
                MeyerAnim.SetBool("B_Walk", true);
            }
        }

        /// Hvis B_MeyerTurn er true så skal det sjekkes om P-Meyer sin y-akse er 
        ///  + eller -
        //float meyerAngle = Vector3.Angle(V3RotMeyer_1, V3Meyer);
        float meyerAngle = transform.eulerAngles.y;
        /*Vector3 targetDir2 = TranRotMeyer2.position - transform.position;
        float meyerAngleDir2 = Vector3.Angle(targetDir2, transform.right);
        Debug.Log(meyerAngleDir2);*/
        /*
        if (B_MeyerTurn == true && B_NotMeyerTurn == false)
        {
            //float meyerAngle = transform.eulerAngles.y;
            /*if (meyerAngle > 180f && meyerAngle < 355f)
            {
                //Debug.Log("Negative");
                MeyerAnim.SetBool("B_R-Turn", true);
                MeyerAnim.SetBool("B_L-Turn", false);
                //print(transform.eulerAngles.y);
            }
            if (meyerAngle > 5f && meyerAngle < 180f)
            {
                //Debug.Log("Positive");
                MeyerAnim.SetBool("B_L-Turn", true);
                MeyerAnim.SetBool("B_R-Turn", false);
                //print(transform.eulerAngles.y);
            }*/
            /*if (meyerAngle > 357f && meyerAngle < 3f)
            {
                //Debug.Log("SAME");
                MeyerAnim.SetBool("B_L-Turn", false);
                MeyerAnim.SetBool("B_R-Turn", false);
                //print(transform.eulerAngles.y);
                B_MeyerTurn = false;
            }*/
            /*
            if (Input.GetKeyDown("s"))
            {
                B_Meyer_L_Turn = true;
            }
            if (Input.GetKeyUp("s"))
            {
                B_Meyer_L_Turn = false;
            }

            if (Input.GetKeyDown("d"))
            {
                B_Meyer_R_Turn = true;
            }
            if (Input.GetKeyUp("d"))
            {
                B_Meyer_R_Turn = false;
            }

            
        }
        if (B_MeyerTurn == true)
        {
            if (meyerAngle < 359f && meyerAngle > 180f)
            {
                Debug.Log("Left" + meyerAngle);
            }
            if (meyerAngle > 1f && meyerAngle < 180f)
            {
                Debug.Log("Right" + meyerAngle);
            }
        }
        if (meyerAngle <= 1f && meyerAngle > 359f)
        {
            Debug.Log("Forward");
            B_MeyerAbleToTurn = false;
        }
        else if (meyerAngle > 1f && meyerAngle < 359f){ B_MeyerAbleToTurn = true; }
        Debug.Log(meyerAngle);
        /*if (meyerAngle >= 355f && meyerAngle <= 5f)
        {
            Debug.Log("SAME");
            MeyerAnim.SetBool("B_L-Turn", false);
            MeyerAnim.SetBool("B_R-Turn", false);
            //print(transform.eulerAngles.y);
            B_NotMeyerTurn = true;
            B_MeyerTurn = false;
        }
        else
        {
            B_NotMeyerTurn = false;
        }*/
        /*
        if (Input.GetKeyDown("a"))
        {
            B_MeyerTurn = true;
        }
        if (Input.GetKeyUp("a"))
        {
            B_MeyerTurn = false;
        }

        if (B_MeyerTurn == false)
        {
            B_Meyer_R_Turn = false;
            B_Meyer_L_Turn = false;
            MeyerAnim.SetBool("B_L-Turn", false);
            MeyerAnim.SetBool("B_R-Turn", false);
        }



    }



    /// Funksjoner som blir spilt av i [Opening_Only] animasjonen. 
    ///  
    public void OpenDoorNout()
    {
        MeyerAnim.SetBool("B_Walk", true);
        B_MeyerOut = true;
    }
    
    public void BackInside()
    {
        if (B_MeyerOut == false)
        {
            MeyerAnim.SetTrigger("T_CloseDoor");
        }
    }
}
*/