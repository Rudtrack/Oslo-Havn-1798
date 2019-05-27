using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour {

    public Transform lookAt;
    private Animator anim;

    public RotOnCam rotoncam;
    public GameObject rotationMaster;

    private LookAtEmpty lookatempty;
    private GameObject lookAtObj;

    public float ikWeight = 0f;
    private float ikMaxValue = 1f;
    private float ikMinValue = 0f;
    public float smooth = 1f;
    public bool ikLookAt = false;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        lookAtObj = GameObject.FindGameObjectWithTag("LookAt");
        lookatempty = lookAtObj.GetComponent<LookAtEmpty>();
        rotoncam = rotationMaster.GetComponent<RotOnCam>();
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ikLookAt = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ikLookAt = false;
        }*/
        if (ikLookAt == false)
        {
            ikWeight = Mathf.Lerp(ikWeight, ikMinValue, smooth * Time.deltaTime);
            if (ikWeight <= 0.05f)
            {
                ikWeight = ikMinValue;
            }
        }
        if (ikLookAt == true)
        {
            ikWeight = Mathf.Lerp(ikWeight, ikMaxValue, smooth * Time.deltaTime);
            if (ikWeight >= 0.95f)
            {
                ikWeight = ikMaxValue;
            }
        }
    }

    public void OnAnimatorIK()
    {
        if (anim)
        {
            anim.SetLookAtWeight(ikWeight, 0.2f, 1, 0, 0.5f);
            anim.SetLookAtPosition(lookAt.position);
        }

        else{}

        
    }


    public void TrueAnimIkWeight()
    {
        rotoncam.BrotOnCam = true;
    }
    public void FalseAnimIkWeight()
    {
        rotoncam.BrotOnCam = false;
    }

    /*public void TrueOnCam()
    {
        lookatempty.onCam = true;
    }
    public void FalseOnCam()
    {
        lookatempty.onCam = false;
    }*/
}
