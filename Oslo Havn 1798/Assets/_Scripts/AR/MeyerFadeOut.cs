using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeyerFadeOut : MonoBehaviour
{
    /// <summary>
    /// Når Meyer fader så skrur den av tingene inni munnen
    /// </summary>

    public GameObject Teeth;
    public GameObject Thoung;
    //private Renderer rend;
    //public GameObject Meyer;
    //private Material[] Mat;
    //private Renderer[] rend;
    //private Shader metallic;
    public GameObject FadeScreen;

    public bool meyActive = true;
    //[Range(0.0f, 1.0f)]
    /*public float current = 0.0f;
    private float min = 0.0f;
    private float max = 1.0f;
    private float smooth = 0.2f;*/

    private void Start()
    {
        //rend = gameObject.GetComponent<Renderer>();
        //metallic = Shader.Find("Metallic");
        //rend = Meyer.GetComponentsInChildren<Renderer>();
        
        //Meyer.GetComponent<Renderer>().material = Mat.ToArray();

        //rend.enabled = true;
        //print(rend.Length);
        //Invoke("GetReferences", 1f);
    }
    public void EnableFadeScreen()
    {
        FadeScreen.SetActive(true);
    }
    public void Update()
    {
        //rend.material.SetFloat("_DissolveCutoff", current);
        /*if (meyActive)
        {
            MeyFadeInn();
        }
        if (!meyActive)
        {
            MeyFadeOut();
        }*/
    }

    /*public void GetReferences()
    {
        //
    }
    public void MeyFadeInn()
    {
        current = min;
        //current = Mathf.Lerp(current, min, smooth);
    }
    public void MeyFadeOut()
    {
        current = Mathf.Lerp(current, max, smooth);
    }

    public void DisableMouth()
    {
        Teeth.SetActive(false);
        Thoung.SetActive(false);
    }
    public void EnableMouth()
    {
        Teeth.SetActive(true);
        Thoung.SetActive(true);
    }*/
}
