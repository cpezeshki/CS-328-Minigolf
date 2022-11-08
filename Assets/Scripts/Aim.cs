using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float minSpeed = 0.1f;

    bool belowMinSpeed;
    int direction;

    Transform golfball;

    void Start()
    {
        belowMinSpeed = false;
        direction = 0;

        golfball = GameObject.Find ("Golfball").GetComponent <Transform> ();
    }

    void Update()
    {
        belowMinSpeed = GameObject.Find("Golfball").GetComponent <Rigidbody> ().velocity.magnitude < minSpeed;


        GameObject.Find ("Aim Indicator").GetComponent <MeshRenderer> ().enabled = belowMinSpeed;

        direction += 1;

        if (direction == 360)
        {
            direction = 0;
        }

        golfball.rotation = Quaternion.Euler (0, direction, 0);

        if (Input.GetKeyUp (KeyCode.Space) && belowMinSpeed)
        {
            GameObject.Find("Golfball").GetComponent<Rigidbody>().velocity = Vector3.zero;

            gameObject.SetActive (false);
        }
    }

    
}
