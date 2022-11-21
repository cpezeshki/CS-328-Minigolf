using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float sensitivity = 3;
    // the velocity threshold before starting a new turn
    public float minVelocity = 0.05f;

    bool belowMinVelocity;
    public float direction;

    Transform golfball;

    public GameObject mulligen;

    void Start()
    {
        belowMinVelocity = false;
        direction = 0;

        golfball = GameObject.Find ("Golfball").GetComponent <Transform> ();
    }

    void Update()
    {
        float currentVelocity;

        currentVelocity = GameObject.Find("Golfball").GetComponent<Rigidbody>().velocity.magnitude;

        belowMinVelocity = currentVelocity < minVelocity;

        GameObject.Find ("Aim Indicator").GetComponent <MeshRenderer> ().enabled = belowMinVelocity;

        if (belowMinVelocity)
        {
            if (Input.GetMouseButtonDown (0))
            {
                gameObject.SetActive(false);
                mulligen.GetComponent<MulligenScript>().SavePlayerPosition();
            }

            GameObject.Find ("Golfball").GetComponent <Rigidbody> ().velocity = Vector3.zero;

            direction += Input.GetAxis ("Mouse X") * sensitivity;

            golfball.rotation = Quaternion.Euler (0, direction, 0);
        }
    }

    
}
