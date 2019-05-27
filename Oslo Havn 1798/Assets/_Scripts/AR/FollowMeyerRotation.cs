using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMeyerRotation : MonoBehaviour
{
    private GameObject Meyer;
    private Transform MeyerT;
    //public Vector3 MeyerV3;
    /*
    private float MeyerX;
    private float MeyerY;
    private float MeyerZ;
    */

    private Transform Parent;

    void Start()
    {
        Meyer = GameObject.FindGameObjectWithTag("P_Meyer");
        MeyerT = Meyer.GetComponent<Transform>();
        Parent = gameObject.GetComponent<Transform>();
    }

    
    void Update()
    {

        //          Gjør at den følger samme rotasjon som Meyer 
        Parent.localEulerAngles = MeyerT.localEulerAngles;
    }
}
