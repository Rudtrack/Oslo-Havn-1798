using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraUI : MonoBehaviour
{
    public ScanningSystem scanningSystem;

    public void BackButton()
    {
        scanningSystem.StopCam();
        SceneManager.LoadScene(0);
    }

    public void ContinueButton()
    {
        scanningSystem.StopCam();
        SceneManager.LoadScene(2);
    }
}
