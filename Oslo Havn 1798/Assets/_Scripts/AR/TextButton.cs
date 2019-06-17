using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButton : MonoBehaviour
{
    /// <summary>
    /// Klikk på texten som kommer på AR plakaten og døra
    ///  dukker opp. Setter alt det andre til SetActive
    ///  true og false basert på en bool
    /// </summary>

    public bool meyerActive;

    public GameObject ObjtoActivate;
    public GameObject ObjDoorRoom;
    public MeyerOutTheDoor motd;

    private Renderer rend;

    public GameObject FadeScreen;

    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update()
    {
        if (meyerActive == true)
        {
            //gameObject.SetActive(false);
            rend.enabled = false;
            ObjtoActivate.SetActive(true);
        }
        if (meyerActive == false)
        {
            //gameObject.SetActive(true);
            rend.enabled = true;
            ObjtoActivate.SetActive(false);
            ObjDoorRoom.SetActive(true);
            motd.B_MeyerOut = false;
            //DisableFadeScreen();
        }
    }

    public void DisableFadeScreen()
    {
        FadeScreen.SetActive(false);
    }
    public void OnMouseDown()
    {
        meyerActive = true;
    }
    
}
