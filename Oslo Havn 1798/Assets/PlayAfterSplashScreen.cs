using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAfterSplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame",6f);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
