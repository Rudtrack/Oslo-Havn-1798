using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            transform.position = transform.position;
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
    CheckPos();
    }

    public void CheckPos()
    {
        if(Camera.main.transform.position.x >= -28.18189f)
        {

        }
    }

}
