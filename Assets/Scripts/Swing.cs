using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public GameObject aimController;
    public GameObject powerController;

    bool aiming;
    bool swinging;
    bool aimed;
    bool swung;

    // Start is called before the first frame update
    void Start ()
    {
        aiming = true;
        swinging = false;
        aimed = false;
        swung = true;

        aimController.SetActive (true);
        powerController.SetActive (false);
    }

    // Update is called once per frame
    void Update ()
    {
        aiming = GameObject.Find ("Aim") != null;
        swinging = GameObject.Find ("Power") != null;

        if (aiming)
        {
            aimed = true;
            swung = false;
        }
        else if (swinging)
        {
            swung = true;
            aimed = false;
        }
        else
        {
            if (!aimed && swung == true)
            {
                aimController.SetActive (true);
            }

            if (aimed && !swung)
            {
                powerController.SetActive (true);
            }
        }
    }
}
