using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRList : MonoBehaviour
{
    public Text qr0;
    public Text qr1;
    public Text qr2;
    public Text qr3;
    public Text qr4;

    private void Awake()
    {
        qr0.text = "QR code 1: Not Completed";
        qr1.text = "QR code 2: Not Completed";
        qr2.text = "QR code 3: Not Completed";
        qr3.text = "QR code 4: Not Completed";
        qr4.text = "QR code 5: Not Completed";
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("QR1_Status") == 1)
        {
            qr0.text = "QR code 1: Completed";
        }

        if (PlayerPrefs.GetInt("QR2_Status") == 1)
        {
            qr1.text = "QR code 2: Completed";
        }

        if (PlayerPrefs.GetInt("QR3_Status") == 1)
        {
            qr2.text = "QR code 3: Completed";
        }

        if (PlayerPrefs.GetInt("QR4_Status") == 1)
        {
            qr3.text = "QR code 4: Completed";
        }

        if (PlayerPrefs.GetInt("QR5_Status") == 1)
        {
            qr4.text = "QR code 5: Completed";
        }
    }
}