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

    [Range(0.0f, 1.0f)]
    public float Shader = 0.0f;

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

    private Renderer rend;
    
    public void Start()
    {
        //MeyerObj = GameObject.FindGameObjectWithTag("P_Meyer");
        //MeyerAnim = MeyerObj.GetComponent<Animator>();
        rend = gameObject.GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        //MeyerAnim.SetTrigger("T_OpenDoor");
    }

    private void Update()
    {
        //rend.material.SetFloat("_DissolveCutoff", Shader);
    }

    public void DoorFade()
    {
        gameObject.SetActive(false);
    }

    public void EnableRoom()
    {
        Backwall.SetActive(true);
        DmRom.SetActive(true);
        Floor.SetActive(true);
        Frontwall.SetActive(true);
        Leftwall.SetActive(true);
        Rightwall.SetActive(true);
        RomShadow.SetActive(true);
        Roof.SetActive(true);
    }
    public void DisableRoom()
    {
        Backwall.SetActive(false);
        DmRom.SetActive(false);
        Floor.SetActive(false);
        Frontwall.SetActive(false);
        Leftwall.SetActive(false);
        Rightwall.SetActive(false);
        RomShadow.SetActive(false);
        Roof.SetActive(false);
    }
}
