using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeyerDoorTrigger : MonoBehaviour
{
    /// <summary>
    /// Eget script som skal holder funkjonen til å åpne døra. 
    ///  Setter Animator triggeren til døra, og blir spilt av 
    ///  i animasjons filen "Opening_Only" via Events Frame 40. 
    /// </summary>

    private Animator DoorAnim;
    public GameObject DoorObj;


    void Start()
    {
        DoorAnim = DoorObj.GetComponent<Animator>();
    }

    public void TOpenDoor()
    {
        DoorAnim.SetTrigger("T_OpenDoor");
    }
    public void TCloseDoor()
    {
        DoorAnim.SetTrigger("T_Closing");
    }
}

