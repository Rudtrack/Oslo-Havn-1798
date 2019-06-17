using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DoorClickable : MonoBehaviour
{

    /// <summary>
    /// Script på Dør+Rom
    /// Kan klikke på døra med musa/fingeren(mobil) for å 
    /// få meyer til å komme ut av rommet. 
    /// </summary>

    [Range(0.0f, 10.0f), ]
    public float slider = 0.0f;

    //private Animator MeyerAnim;
    //private GameObject MeyerObj;

    public GameObject Backwall;
    public GameObject DmRom;
    public GameObject Floor;
    public GameObject Frontwall;
    public GameObject Leftwall;
    public GameObject Rightwall;
    public GameObject RomShadow;
    public GameObject Roof;


    
    public void Start()
    {
        //MeyerObj = GameObject.FindGameObjectWithTag("P_Meyer");
        //MeyerAnim = MeyerObj.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        //MeyerAnim.SetTrigger("T_OpenDoor");
    }
    
    public void DoorFade()
    {
        gameObject.SetActive(false);
    }

    public void EnableRoom()
    {

    }
}
