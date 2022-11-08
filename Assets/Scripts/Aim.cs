using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    int direction;

    Transform golfball;

    void Start()
    {
        direction = 0;

        golfball = GameObject.Find ("Golfball").GetComponent <Transform> ();
    }

    void Update()
    {
        direction += 1;

        if (direction == 360)
        {
            direction = 0;
        }

        golfball.rotation = Quaternion.Euler (0, direction, 0);

        if (Input.GetKeyUp (KeyCode.Space))
        {
            gameObject.SetActive (false);
        }
    }

    
}
