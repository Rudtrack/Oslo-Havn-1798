using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject qr0_Completed;
    public GameObject qr1_Completed;
    public GameObject qr2_Completed;
    public GameObject qr3_Completed;
    public GameObject qr4_Completed;

    private void Awake()
    {
        qr0_Completed.SetActive(false);
        qr1_Completed.SetActive(false);
        qr2_Completed.SetActive(false);
        qr3_Completed.SetActive(false);
        qr4_Completed.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("QR1_Status") == 1)
        {
            qr0_Completed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("QR2_Status") == 1) 
        {
            qr1_Completed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("QR3_Status") == 1)
        {
            qr2_Completed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("QR4_Status") == 1)
        {
            qr3_Completed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("QR5_Status") == 1)
        {
            qr4_Completed.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.End))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All PlayerPrefs successfully deleted");
        }
    }

} 