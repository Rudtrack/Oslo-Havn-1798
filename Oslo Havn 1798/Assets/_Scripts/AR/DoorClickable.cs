using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClickable : MonoBehaviour
{
    /// <summary>
    /// Script på Dør+Rom
    /// Kan klikke på døra med musa/fingeren(mobil) for å 
    /// få meyer til å komme ut av rommet. 
    /// </summary>


    //private Animator MeyerAnim;
    //private GameObject MeyerObj;
    
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
}
