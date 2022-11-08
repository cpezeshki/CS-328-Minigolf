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
    void Start()
    {
        aiming = false;
        swinging = false;
        aimed = false;
        swung = false;
    }

    // Update is called once per frame
    void Update()
    {
        aiming = GameObject.Find ("Aim") != null;
        swinging = GameObject.Find ("Power") != null;

        if (Input.GetKeyUp (KeyCode.Space) && aiming == false && swinging == false && aimed == false && swung == false)
        {
            GameObject aim = Instantiate (aimController) as GameObject;
            aim.transform.parent = transform;
            aim.SetActive (true);

            aimed = true;
        }

        if (Input.GetKeyUp (KeyCode.Space) && aiming == false && swinging == false && aimed == true && swung == false)
        {
            GameObject power = Instantiate (powerController) as GameObject;
            power.transform.parent = transform;
            power.SetActive (true);

            swung = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && aiming == false && swinging == false && aimed == true && swung == true)
        {
            aimed = false;
            swung = false;
        }
    }
}
