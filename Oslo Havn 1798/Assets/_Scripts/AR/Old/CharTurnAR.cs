using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTurnAR : MonoBehaviour {

    //private Animator anim;
    private GameObject player;
    private Animator playerAnim;

    public RotOnCam rotoncam;
    public GameObject rotObj;
    public Animator rotAnim;

    public bool turnRight = false;
    public bool turnLeft = false;
    public bool charOnCam = false;

    

	void Start () {
        //anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();

        rotoncam = rotObj.GetComponent<RotOnCam>();
        rotAnim = rotObj.GetComponent<Animator>();
	}
	
	
	void Update () {
        /*if (charOnCam == true)
        {
            rotoncam.BrotOnCam = true;
        }
        else
        {
            rotoncam.BrotOnCam = false;
        }*/
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Outtrigger" && rotoncam.BrotOnCam == true)
        {
            playerAnim.SetTrigger("T_Vinke");
        }
        if (collider.tag == "Rtrigger" && rotoncam.BrotOnCam == true)
        {
            turnRight = true;
            playerAnim.SetBool("B_Right-Turn", true);
            
        }
        if (collider.tag == "Ltrigger" && rotoncam.BrotOnCam == true)
        {
            turnLeft = true;
            playerAnim.SetBool("B_Left-Turn", true);
        }

        if (collider.tag == "Ftrigger")
        {
            turnLeft = false;
            turnRight = false;
            playerAnim.SetBool("B_Left-Turn", false);
            playerAnim.SetBool("B_Right-Turn", false);
            //playerAnim.SetTrigger("T_Idle");
            /*if (rotoncam.BrotOnCam == false)
            {
                rotoncam.BrotOnCam = true;
                playerAnim.SetTrigger("T_Bukking");
            }
            if (rotoncam.BrotOnCam == true)
            {

            }*/
        }
        

    }
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Ftrigger" && rotoncam.BrotOnCam == false)
        {
            rotoncam.BrotOnCam = true;
            //playerAnim.SetTrigger("T_Bukking");
            //playerAnim.ResetTrigger("T_Vinke");
        }
        if (collider.tag == "Rtrigger" && rotoncam.BrotOnCam == false)
        {
            rotoncam.BrotOnCam = true;
            //playerAnim.SetTrigger("T_Bukking");
            
        }
        if (collider.tag == "Ltrigger" && rotoncam.BrotOnCam == false)
        {
            rotoncam.BrotOnCam = true;
            //playerAnim.SetTrigger("T_Bukking");
            
        }


        if (rotoncam.BrotOnCam == true)
        {

        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Rtrigger")
        {
            turnRight = false;
            playerAnim.SetBool("B_Right-Turn", false);
        }
        if (collider.tag == "Ltrigger")
        {
            turnLeft = false;
            playerAnim.SetBool("B_Left-Turn", false);
        }
        
    }
}
