using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotation : MonoBehaviour {

    
    private CharTurnAR charturn;
    private GameObject lookAt;

    public float turnSpeed = 100f;

    public void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("LookAt");
        charturn = lookAt.GetComponent<CharTurnAR>();
    }

    public void Update () {
        
        if (charturn.turnLeft == true)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (charturn.turnRight == true)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        

    }
}
