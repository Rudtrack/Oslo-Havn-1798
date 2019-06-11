using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    ///      Døra
    private Animator animRD;
    private GameObject objRD;

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
    /*
    public Transform TranRotMeyer1;
    public Transform TranRotMeyer2;
    public Transform TranRotMeyer3;
    */
    ///     MiniManager
    private GameObject MiniManObj;
    private Animator MiniManAnim;

    public bool B_meyFade = false;


    /// Floats for lerping
    //public float LerpTime = 0.1f;
    // Adjust the speed for the application.
    private float speed = 2f;
    private float rotSpeed = 5.0f;


    ///  For å justere om Animator Layeret "UpperBody"
    ///   være på eller ikke. 
    public bool uBody = false;
    private float ubLayer = 0f;
    private readonly float mainIkMax = 1; // Brukes kun for "upLayer" mathf.lerp
    private readonly float minF = 0; // Brukes kun for "upLayer" mathf.lerp


    ///     For å skru på Ikonene på døra igjen når Meyer går inn igjen. 
    private RealWorldSpaceManager realworldspacemanager;
    private GameObject ObjRWSM;

    public TextButton tb;
    

    void Start()
    {

        ObjPosMeyer_1 = GameObject.FindGameObjectWithTag("MeyerPos_1");
        ObjPosMeyer_2 = GameObject.FindGameObjectWithTag("MeyerPos_2");
        ObjRotMeyer_1 = GameObject.FindGameObjectWithTag("MeyerRot_1");
        ObjRotMeyer_2 = GameObject.FindGameObjectWithTag("MeyerRot_2");
        ObjRWSM = GameObject.FindGameObjectWithTag("RealWorldSpaceManager");
        objRD = GameObject.FindGameObjectWithTag("Door+Room");

        animRD = objRD.GetComponent<Animator>();
        realworldspacemanager = ObjRWSM.GetComponent<RealWorldSpaceManager>();

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
        /*if (Input.GetKey("x"))
        {
            //B_MeyerOut = true;
            MeyerAnim.SetTrigger("T_OpenDoor");
        }
        if (Input.GetKey("c"))
        {
            B_MeyerOut = false;
            //BackInside();
            MeyerAnim.SetTrigger("T_CloseDoor");
        }*/


        // Hvis B_MeyerOut er false så skal Meyer lerpe tilbake til posisjon 2
        if (B_MeyerOut == false)
        {
            transform.position = V3PosMeyer_2;
            //transform.eulerAngles = V3PosMeyer_2;
            //B_meyFade = true;
            //V3Meyer = V3PosMeyer_2;
            /*transform.position = Vector3.MoveTowards(transform.position, V3PosMeyer_2, step);
            if (Vector3.Distance(transform.position, V3PosMeyer_2) < 0.13f)
            {
                //Debug.Log("Inside");
                MeyerAnim.SetBool("B_WalkBack", false);
                MeyerAnim.SetTrigger("T_CloseDoor");
                uBody = false;
            }
            else
            {
               // Debug.Log("Inbetween");
                MeyerAnim.SetBool("B_WalkBack", true);
                uBody = false;
                B_meyFade = false;
            }*/
        }
        // Hvis B_MeyerOut er true, så lerper Meyer til posisjon 1
        if (B_MeyerOut == true)
        {
            B_meyFade = false; 
            //V3Meyer = V3PosMeyer_1;
            transform.position = Vector3.MoveTowards(transform.position, V3PosMeyer_1, step);
            if (Vector3.Distance(transform.position, V3PosMeyer_1) < 0.13f)
            {
                //Debug.Log("Outside");
                MeyerAnim.SetBool("B_Walk", false);
                //B_MeyerOut = false;
                MiniManAnim.SetTrigger("T_Outside");
                uBody = true;
                animRD.SetTrigger("T_Closing");
            }
            else
            {
                //Debug.Log("Inbetween");
                MeyerAnim.SetBool("B_Walk", true);
                uBody = false;
            }
        }

        



        ///  Animator UpperBody layer
        ///   Dette er for å kunne skru upperbody layer (animator) av og på. 
        ///    Blir true når Meyer er i position 1 
        if (uBody == true)
        {
            ubLayer = Mathf.Lerp(ubLayer, mainIkMax, 0.5f);
            if (ubLayer > 0.99f)
            {
                ubLayer = mainIkMax;
            }
        }
        if (uBody == false)
        {
            ubLayer = Mathf.Lerp(ubLayer, minF, 0.5f);
            if (ubLayer < 0.01f)
            {
                ubLayer = minF;
            }
        }

        MeyerAnim.SetLayerWeight(MeyerAnim.GetLayerIndex("UpperBody"), ubLayer);

        /// Hvis B_MeyerTurn er true så skal det sjekkes om P-Meyer sin y-akse er 
        ///  + eller -
        ///             Rotere Meyer manuelt (Test)
        /*
        Vector3 targetDir1 = TranRotMeyer2.position - transform.position;
        Vector3 targetDir3 = TranRotMeyer3.position - transform.position;
        float rotering = rotSpeed * Time.deltaTime;
        float meyerAngle = transform.eulerAngles.y;

        if (B_MeyerTurn == true)
        {
            V3Meyer = Vector3.RotateTowards(transform.forward, targetDir1, rotering, 0.5f);
            transform.rotation = Quaternion.LookRotation(V3Meyer);
            if (meyerAngle > 1f && meyerAngle < 179f)
            {
                MeyerAnim.SetBool("B_R-Turn", true);
            }
            if (meyerAngle > 181f && meyerAngle < 359f)
            {
                MeyerAnim.SetBool("B_L-Turn", true);
            }
            if (meyerAngle > 359f && meyerAngle < 1f)
            {
                MeyerAnim.SetBool("B_L-Turn", false);

            }
            if (meyerAngle > 179f && meyerAngle < 181f)
            {
                MeyerAnim.SetBool("B_L-Turn" + "B_R-Turn", false);
            }
        }
        if (B_MeyerTurn == false)
        {
            /*V3Meyer = Vector3.RotateTowards(transform.forward, targetDir3, rotering, 0.5f);
            transform.rotation = Quaternion.LookRotation(V3Meyer);
            if (meyerAngle > 1f && meyerAngle < 179f)
            {
                MeyerAnim.SetBool("B_R-Turn", true);
            }
            if (meyerAngle > 181f && meyerAngle < 359f)
            {
                MeyerAnim.SetBool("B_L-Turn", true);
            }
            if (meyerAngle > 359f && meyerAngle < 1f)
            {
                MeyerAnim.SetBool("B_L-Turn" + "B_R-Turn", false);
            }
            if (meyerAngle > 179f && meyerAngle < 181f)
            {
                MeyerAnim.SetBool("B_L-Turn" + "B_R-Turn", false);
            }*/
        /*}
    
        print(meyerAngle);
        if (Input.GetKeyDown("a"))
        {
            B_MeyerTurn = true;
        }
        if (Input.GetKeyUp("a"))
        {
            B_MeyerTurn = false;
        }*/
    }

    public void GoodbyeRestart()
    {
        tb.meyerActive = false;
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

    public void EnableDoorButtonMOTD()
    {
        realworldspacemanager.EnableDoorButtonRWSM();
    }
}
