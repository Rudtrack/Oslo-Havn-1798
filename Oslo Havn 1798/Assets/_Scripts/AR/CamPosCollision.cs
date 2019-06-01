using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosCollision : MonoBehaviour
{
    /// <summary>
    /// Scriptet på [ObjCamPosition]. Sjekker hvor kameraet er til hver tid
    ///  og hva det kolliderer med. En rekke bools her blir skrudd av og på
    ///  basert på collisions, og blir referert til i [MeyerLookAtCam]. 
    ///
    /// Har også noen direkte SetTriggers til Meyer sin animator. 
    ///         (Turn, vink, angry & happy)
    /// </summary>



    //Collision Bools
    public bool B_EyeIk;
    public bool B_HeadIk;
    public bool B_ChestIk;

    public bool B_EyeOnly;
    public bool B_HeadnEye;

    public bool B_Master;

    //  Meyer karakteren
    private GameObject Meyer;
    private Animator MeyerAnim;

    //  AudioSource MEYER
    private GameObject AudiObj;
    private Animator AudiAnim;

    //  Camera collider som sjekker hvor man ser
    private GameObject LookPath;
    private bool B_LookPath = true;

    //      MiniManager
    private GameObject MiniManObj;
    private Animator MiniManAnim;

    public void Start()
    {
        Meyer = GameObject.FindGameObjectWithTag("P_Meyer");
        MeyerAnim = Meyer.GetComponent<Animator>();

        AudiObj = GameObject.FindGameObjectWithTag("SourceAudio");
        AudiAnim = AudiObj.GetComponent<Animator>();

        LookPath = GameObject.FindGameObjectWithTag("Cam_LookPath");

        MiniManObj = GameObject.FindGameObjectWithTag("MiniManager");
        MiniManAnim = MiniManObj.GetComponent<Animator>();
    }

    public void Update()
    {
        // Hvis B_Master er false så blir alle bools resatt
        if (B_Master == false)
        {
            B_EyeIk = false;
            B_HeadIk = false;
            B_ChestIk = false;
            B_EyeOnly = false;
            B_HeadnEye = false;
        }
        
        
        //Setter B_EyeIk = true basert på B_EyeOnly
        /*if (B_EyeOnly == true)
        {
            B_EyeIk = true;
            B_HeadnEye = false;
            B_ChestIk = false;
        }*/
        

        //Setter B_HeadIk = true eller false basert på B_HeadnEye
        if (B_HeadnEye == true)
        {
            B_HeadIk = true;
            B_EyeIk = true;
        }
        if (B_HeadnEye == false && B_ChestIk == false)
        {
            B_HeadIk = false;
        }

        if (B_ChestIk == true)
        {
            B_HeadnEye = true;
        }

        // Gjør B_ChestIk aktiv slik at chest IK følger brukeren
        /*if (B_EyeOnly == false && B_HeadnEye == false && B_Master == true)
        {
            B_ChestIk = true;
            B_HeadnEye = true;
        }
        else { B_ChestIk = false; }*/

        ///  Hvis Boolen for lookpath er false så er Cam_LookingPath satt til
        ///   deactivated. Motsatt hvis boolen er true.
        if (B_LookPath == false) { LookPath.SetActive(false); }
        if (B_LookPath == true) { LookPath.SetActive(true); }

    }


    public void OnTriggerExit(Collider col)
    {
        // Forlater TAG_EyeIK og setter B_EyeOnly til false
        /*if (col.gameObject.tag == "TAG_EyeIK")
        {
            Debug.Log("NOT");
            B_EyeOnly = false;
        }*/

        // Forlater TAG_HeadIK og setter B_HeadnEye til false
        if (col.gameObject.tag == "TAG_HeadIK" && B_Master == true)
        {
            //B_ChestIk = true;
            
        }
  
        // Forlater TAG_ChestIK og gjør chest boolen til false
        if (col.gameObject.tag == "TAG_ChestIK")
        {
            B_ChestIk = false;
        }

        // Forlater Master_OnCam som er Meyer_Position_1 og setter alle relevante bools til false 
        if (col.gameObject.tag == "TAG_MasterPos-1")
        {
            B_Master = false;

            ///     Gjør at meyer vinker når kameraet går ut av MasterTriggeren
            //MeyerAnim.SetTrigger("T_Wave");
            MeyerAnim.SetBool("B_Wave", true);

            ///     Audiotrigger for at brukeren går out of bounds
            //AudiAnim.SetTrigger("T_Goodbye");

            ///     MiniManager
            MiniManAnim.SetBool("B_Outside", false);
        }

    }
    public void OnTriggerStay(Collider col)
    {
        // Ser om den holder seg i Master_OnCam/Meyer_Position_1
        if (col.gameObject.tag == "TAG_MasterPos-1")
        {
            B_Master = true;

            ///     Hvis kameraet er inne i MasterTriggeren så vil ikke Meyer vinke, 
            ///     og gå tilbake til idle fra Hold 3 i animatoren 
            MeyerAnim.SetBool("B_Wave", false);

            ///     MiniManager
            MiniManAnim.SetBool("B_Outside", true);
        }
        
        //Holder seg inni EyeCollider
        /*if (col.gameObject.tag == "TAG_EyeIK")
        {
            //Debug.Log("Eyes");
            //B_EyeIk = true;
            B_HeadIk = false;
            B_ChestIk = false;
            if (B_EyeOnly == false)
            {
                B_EyeOnly = true;
                B_HeadnEye = false;
            }

        }*/

        //Ute av EyeCollider og får setter HeadIK til true
        if (col.gameObject.tag == "TAG_HeadIK" /*&& B_EyeOnly == false*/)
        {
            //Debug.Log("Head");
            //B_HeadIk = true;
            B_HeadnEye = true;
            B_ChestIk = false;
            if (B_HeadnEye == false && B_EyeOnly == false)
            {
                B_HeadnEye = true;
            }
        }

        // Ute av EyeCollider og HeadCollider for å sette ChestIK til true
        if (col.gameObject.tag == "TAG_ChestIK")
        {
            B_ChestIk = true;
           // Debug.Log("Chest");
        }

        ///-----------------------------------------------------------------------
        //      Meyer snur seg. Treffer Turn objektet
        //          Venstre
        if (col.gameObject.tag == "TAG_L-Turn")
        {
            MeyerAnim.SetTrigger("T_L-Turn");
        }
        //          Høyre
        if (col.gameObject.tag == "TAG_R-Turn")
        {
            MeyerAnim.SetTrigger("T_R-Turn");
        }

        ///
        TEnter();
    }

    public void TExit()
    {
        /// Gjør at Meyer går umiddelbart fra angry/happy over til Hold (Wave).
        MeyerAnim.SetTrigger("T_Exit");
    }
    public void TEnter()
    {
        B_LookPath = true;
    }
    public void DeactivateCamLook()
    {
        ///  Deaktiverer Syns triggeren som ligger under AR kameraet
        B_LookPath = false;
    }
}
