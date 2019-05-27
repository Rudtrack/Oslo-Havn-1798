using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamBackButton : MonoBehaviour
{
    public ScanningSystem scanningSystem;

    public void BackButton()
    {
        scanningSystem.StopCam();
        SceneManager.LoadScene(0);
    }
}
