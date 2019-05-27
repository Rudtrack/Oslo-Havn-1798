using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTurn : MonoBehaviour {

    //private Animator anim;
    private GameObject player;
    private Animator playerAnim;

	void Start () {
        //anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
	}
	
	
	void Update () {


        /*
		if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("T_Left-Turn");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("T_Right-Turn");
        }*/
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Rtrigger")
        {
            playerAnim.SetTrigger("T_Right-Turn");
        }
        if (collider.tag == "Ltrigger")
        {
            playerAnim.SetTrigger("T_Left-Turn");
        }

        if (collider.tag == "Ftrigger")
        {
            playerAnim.SetTrigger("T_Idle");
        }
    }
}
