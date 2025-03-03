﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFinger : MonoBehaviour
{

    Vector3 touchStart;
    bool canMove;

    float maxPosX_Left = -30f;
    float maxPostX_Right = 189f;
    float maxPostY_Up = 25f;
    float maxPostY_Down = 26f;

    bool move;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            transform.position = transform.position;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        else
        {
            Camera.main.transform.position = Camera.main.transform.position;
        }
    }


    private void CheckConstraints()
    {
        if (!move)
        {

        }
        else
        {

        }
    }
}
