using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenOrient : MonoBehaviour
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

            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            Screen.autorotateToLandscapeLeft = false;

            Screen.autorotateToLandscapeRight = false;

            Screen.autorotateToPortrait = true;

            Screen.autorotateToPortraitUpsideDown = true;

            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
