using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float sensitivity = 3;
    // the speed threshold before starting a new turn
    public float minSpeed = 0.1f;

    bool belowMinSpeed;
    float direction;

    Transform golfball;

    void Start()
    {
        belowMinSpeed = false;
        direction = 0;

        golfball = GameObject.Find ("Golfball").GetComponent <Transform> ();
    }

    void Update()
    {
        belowMinSpeed = GameObject.Find ("Golfball").GetComponent <Rigidbody> ().velocity.magnitude < minSpeed;

        GameObject.Find ("Aim Indicator").GetComponent <MeshRenderer> ().enabled = belowMinSpeed;

        if (belowMinSpeed)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                gameObject.SetActive(false);
            }

            GameObject.Find ("Golfball").GetComponent <Rigidbody> ().velocity = Vector3.zero;

            direction += Input.GetAxis ("Mouse X") * sensitivity;

            golfball.rotation = Quaternion.Euler (0, direction, 0);
        }
    }

    
}
