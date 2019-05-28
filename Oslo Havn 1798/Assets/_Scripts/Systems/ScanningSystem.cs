using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using ZXing;
using ZXing.QrCode;

public class ScanningSystem : MonoBehaviour
{
    private Rect screenRect;
    private WebCamTexture camTexture;

    private bool scanned = false;
    private int sceneNumber;

    private IEnumerator coroutine;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height / 1;
        camTexture.requestedWidth = Screen.width / 1;

        if (camTexture != null)
        {
            scanned = false;
            camTexture.Play();
            rend.material.mainTexture = camTexture;
        }

        coroutine = ScanCam(0.5f);
        StartCoroutine(coroutine);
    }

    private IEnumerator ScanCam(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);

            // do the reading
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame

                var result = barcodeReader.Decode(camTexture.GetPixels32(),
                  camTexture.width, camTexture.height);
                if (result != null && scanned == false)
                {
                    camTexture.Stop();
                    scanned = true;
                    //Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                    //Application.OpenURL(result.Text);

                    string data = result.Text;
                    sceneNumber = int.Parse(data);

                    Invoke("ReactivateScanning", 1f);
                    Debug.Log(sceneNumber);

                    if (sceneNumber == 1)
                    {
                        PlayerPrefs.SetInt("QR1_Status", 1);
                    }

                    if (sceneNumber == 2)
                    {
                        PlayerPrefs.SetInt("QR2_Status", 1);
                    }

                    if (sceneNumber == 3)
                    {
                        PlayerPrefs.SetInt("QR3_Status", 1);
                    }

                    if (sceneNumber == 4)
                    {
                        PlayerPrefs.SetInt("QR4_Status", 1);
                    }

                    if (sceneNumber == 5)
                    {
                        PlayerPrefs.SetInt("QR5_Status", 1);
                    }

                    result = null;
                    SceneManager.LoadScene(sceneNumber);
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }

        }
       
    }

    private static Color32[] Encode(string textForEncoding,
    int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    private void ReactivateScanning()
    {
        scanned = false;
    }

    public void StopCam()
    {
        camTexture.Stop();
    }
}
