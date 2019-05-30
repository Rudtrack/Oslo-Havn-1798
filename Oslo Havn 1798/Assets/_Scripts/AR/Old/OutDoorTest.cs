using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoorTest : MonoBehaviour {

    public Animator DorRom;
    public GameObject DorRomObj;
    public Animator MrAnim;
    public GameObject MrDude;

    public GameObject canvasObj;

    public RotOnCam rotoncam;
    public GameObject rotObj;
    public Animator rotAnim;

    private void Start()
    {
        DorRom = DorRomObj.GetComponent<Animator>();
        MrAnim = MrDude.GetComponent<Animator>();

        rotoncam = rotObj.GetComponent<RotOnCam>();
        rotAnim = rotObj.GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OpenDoor();
        }
    }

    public void OnMouseDown()
    {
        
        //Debug.Log("!!!Door!!!");
    }

    public void OpenDoor()
    {
        canvasObj.SetActive(false);
        rotoncam.activeBo = true;
        DorRom.SetTrigger("T_OpenDoor");
        MrAnim.SetTrigger("T_MrD_OpenDoor");
    }
}
