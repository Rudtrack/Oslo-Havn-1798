using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeyerLookatCam : MonoBehaviour
{
    /// <summary>
    /// Rekke float verdier som blir brukt i [public void OnAnimatorIK]
    ///  Basert på bools fra [CamPosCollision] så blir de ulike float 
    ///  verdiene lerpet fram og tilbake. 
    /// </summary>


    private Animator anim;
    private Transform lookAt;

    public float F_HeadIK = 0;
    public float F_ChestIK = 0;

    //For å få scriptet fra ObjCamPosition
    private GameObject lookAtObj;
    private CamPosCollision camposcollision;

    //Verdier for IK'ene. Brukes i update med Mathf.Lerp
    public float eyeIkF = 0;
    public float headIkF = 0;
    public float chestIkF = 0;
    public float mainIk = 0;

    private readonly float mainIkMax = 1;
    private readonly float headMaxF = 0.6f;
    private readonly float chestMaxF = 0.5f;
    private readonly float minF = 0;
    private readonly float lerpSmooth1 = 2;

    ///     HVIS animator layeret Jaw skal lerpes 
    ///     inn og ut så brukes boolen og float 
    ///     verdien under her. 
    //public bool talking = false;
    //private float jawLayer = 0f;


    /*public bool uBody = false;
    private float ubLayer = 0f;*/



    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        lookAtObj = GameObject.FindGameObjectWithTag("LookAt");
        lookAt = lookAtObj.GetComponent<Transform>();
        camposcollision = lookAtObj.GetComponent<CamPosCollision>();
    }

    public void Update()
    {
        ///         HeadIK          Mathf.Lerp
        //Når bool B_HeadIk == true går headIkF Mathf.Lerp opp til maxF (CamPosCollision Script)
        if (camposcollision.B_HeadnEye == true)
        {
            headIkF = Mathf.Lerp(headIkF, headMaxF, lerpSmooth1 * Time.deltaTime);
            if (headIkF >= 0.59f)
            {
                headIkF = headMaxF;
            }
        }
        //Motsatt av den over. Setter den smoothly ned til 0
        if (camposcollision.B_HeadnEye == false)
        {
            headIkF = Mathf.Lerp(headIkF, minF, lerpSmooth1 * Time.deltaTime);
            if (headIkF <= 0.01f) { headIkF = minF; }
        }
        ///___________________________________________________________________________
        

        ///         ChestIK         Mathf.Lerp
        // B_ChestIk = true. Mathf.Lerp til maxverdien så han snur brystet mot brukeren
        if (camposcollision.B_ChestIk == true)
        {
            chestIkF = Mathf.Lerp(chestIkF, chestMaxF, lerpSmooth1 * Time.deltaTime);
            if (chestIkF >= 0.49f) { chestIkF = chestMaxF; }
        }
        // B_ChestIk = false. Blir motsatt av den over
        if (camposcollision.B_ChestIk == false)
        {
            chestIkF = Mathf.Lerp(chestIkF, minF, lerpSmooth1 * Time.deltaTime);
            if (chestIkF <= 0.01f) { chestIkF = minF; }
        }
        ///______________________________________________________________________________
        
        ///             Main IK
        // Setter main Ik til 1 hvis B_Master er true
        if (camposcollision.B_Master == true)
        {
            mainIk = Mathf.Lerp(mainIk, mainIkMax, lerpSmooth1 * Time.deltaTime);
            if (mainIk >= 0.99f) { mainIk = mainIkMax; }
        }
        // B_Master = false og main Ik går til 0
        if (camposcollision.B_Master == false)
        {
            mainIk = Mathf.Lerp(mainIk, minF, lerpSmooth1 * Time.deltaTime);
            if (mainIk <= 0.01f) { mainIk = minF; }
        }
        ///______________________________________________________________________________



        ///         HVIS det trengs at animator layer Jaw trenger å lerpes inn og ut så brukes
        ///          denne delen for det. Trenger bare referere til boolen "talking".
        /*if (talking == true)
        {
            jawLayer = Mathf.Lerp(jawLayer, mainIkMax, 0.5f);
            if (jawLayer > 0.99f)
            {
                jawLayer = mainIkMax;
            }
        }
        if (talking == false)
        {
            jawLayer = Mathf.Lerp(jawLayer, minF, 0.5f);
            if (jawLayer < 0.01f)
            {
                jawLayer = minF;
            }
        }

        anim.SetLayerWeight(anim.GetLayerIndex("Jaw"), jawLayer);*/
        ///-------------------------------------------------------------------------------


       ///  Animator UpperBody layer
       ///   Dette er for å kunne skru upperbody layer (animator) av og på. 
       ///    Blir true når Meyer er i position 1 
       /*if (uBody == true)
       {
           ubLayer = Mathf.Lerp(ubLayer, mainIkMax, 0.5f);
           if (ubLayer> 0.99f)
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

       anim.SetLayerWeight(anim.GetLayerIndex("UpperBody"), ubLayer);*/

    }


    public void OnAnimatorIK()
    {
        
        anim.SetLookAtWeight(mainIk, chestIkF, headIkF, 1, 0.5f);
        anim.SetLookAtPosition(lookAt.position);
    
    }
}
