using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    public TextButton tb;

    public void DisableFadeScreen()
    {
        gameObject.SetActive(false);
        
    }
    public void EnableTB()
    {
        tb.meyerActive = false;
    }
}
