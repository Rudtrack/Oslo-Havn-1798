using System.Collections;
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
    /// Når Meyer skal inn døra igjen, og når han er inne i døra, så 
    ///  skal den sjekke om rotasjonen matcher Meyer_Rotation_1&2. 
    ///  Hvis den ikke gjør det så skal Meyer rotere seg slik at den 
    ///  matcher rotasjon. Bruker Turn-Animasjonen for å snu Meyer. 
    ///  
    /// Ligger på [P-Meyer]
    /// </summary>


    ///      Bool for å sjekke om Meyer skal ut eller ikke. True er ut
    public bool B_MeyerOut = false;


    ///      Bools for å sjekke om Meyer skal rotere seg eller ikke, og 
    ///       hvilken retning han skal rotere seg. 
    public bool B_MeyerTurn = false;
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
            if (Vector3.Distance(transform.position, V3PosMeyer_2) < 0.01f)
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
            if (Vector3.Distance(transform.position, V3PosMeyer_1) < 0.01f)
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
        if (B_MeyerTurn == true)
        {
            if (Vector3.Angle(V3RotMeyer_1, V3Meyer) > 0)
            {
                B_
            }
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