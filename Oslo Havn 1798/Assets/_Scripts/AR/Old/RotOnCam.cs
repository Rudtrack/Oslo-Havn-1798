using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotOnCam : MonoBehaviour {

    public bool BrotOnCam = false;

    public bool activeBo = false;

    public LookatCamera lookatcamera;
    public GameObject player;
    public Animator playerAnim;

    public GameObject rightTrig;
    public GameObject leftTrig;
    public GameObject frontTrig;
    public GameObject outTrig;

    private Animator rotAnim;
	
	void Start () {
        lookatcamera = player.GetComponent<LookatCamera>();
        playerAnim = player.GetComponent<Animator>();

        rotAnim = gameObject.GetComponent<Animator>();

        
	}
	
	public void Update () {

        if (BrotOnCam == true)
        {
            IkCamOn();
            
        }
        if (BrotOnCam == false)
        {
            IkCamOff();
            
        }

        if (activeBo == false)
        {
            DisableTriggers();
        }
        if (activeBo == true)
        {
            ActivateTriggers();
        }
    }

    public void IkCamOn()
    {
        lookatcamera.ikLookAt = true;
        rotAnim.SetBool("B_Rot_OnCam", true);
    }
    public void IkCamOff()
    {
        lookatcamera.ikLookAt = false;
        rotAnim.SetBool("B_Rot_OnCam", false);
    }

    public void DisableTriggers()
    {
        rightTrig.SetActive(false);
        leftTrig.SetActive(false);
        frontTrig.SetActive(false);
        outTrig.SetActive(false);
    }
    public void ActivateTriggers()
    {
        rightTrig.SetActive(true);
        leftTrig.SetActive(true);
        frontTrig.SetActive(true);
        outTrig.SetActive(true);
    }
}
