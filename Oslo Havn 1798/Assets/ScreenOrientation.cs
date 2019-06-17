using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenOrientation : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = false;
        }
        else
        {
            Screen.autorotateToLandscapeLeft = false;

            Screen.autorotateToLandscapeRight = false;

            Screen.autorotateToPortrait = true;

            Screen.autorotateToPortraitUpsideDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
