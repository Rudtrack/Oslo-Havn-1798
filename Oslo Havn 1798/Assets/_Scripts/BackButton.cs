using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class BackButton : MonoBehaviour
{
    private DisplaySettings dS; 

    public void ReturnToLandingpage()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnAndWaitForTiltScreen()
    {
        Invoke("ReturnToLandingpage", 3.5f);
        
    }
}
