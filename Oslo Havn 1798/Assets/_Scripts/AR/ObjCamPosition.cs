using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCamPosition : MonoBehaviour
{
    private float smooth1 = 2;
    private float smooth2 = 6;

    private Vector3 newPosition;
    public Vector3 VcamPosition;
    private GameObject arCamera;
    private Transform camPosition;

    public bool onCam = true;

    

    void Start()
    {
        newPosition = transform.localPosition;
        arCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camPosition = arCamera.GetComponent<Transform>();
    }

    void Update()
    {
        VcamPosition = camPosition.position;

        PositionChanging();


    }

    public void PositionChanging()
    {
        Vector3 positionA = new Vector3(-1, 0.8402761f, 0.7371743f);
        Vector3 positionB = new Vector3(1, 0.8402761f, 0.7371743f);
        Vector3 positionC = new Vector3(0, 0.8402761f, 0.7371743f);


        if (onCam == true)
        {
            transform.position = Vector3.Lerp(transform.position, VcamPosition, Time.deltaTime * smooth2);
        }
        if (onCam == false)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, Time.deltaTime * smooth1);
        }

    }

    
}
