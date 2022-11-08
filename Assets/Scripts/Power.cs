using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float strengthMultiplier = 0.1f;
    public int minStrength = 1;
    public int maxStrength = 100;

    bool increasing;
    int strength;

    Rigidbody golfball;
    Transform indicator;

    void Start ()
    {
        increasing = true;
        strength = minStrength;

        golfball = GetComponentInParent <Rigidbody> ();
        indicator = transform.GetChild(0).transform;
    }

    void Update ()
    {
        Vector3 indicatorLevel = indicator.position;

        if (increasing)
        {
            strength += 1;
            indicatorLevel.y += 0.002f;
        }
        else
        {
            strength -= 1;
            indicatorLevel.y -= 0.002f;
        }

        if (strength == minStrength)
        {
            increasing = true;
        }

        if (strength == maxStrength)
        {
            increasing = false;
        }

        if (Input.GetKeyUp (KeyCode.Space))
        {
            golfball.AddRelativeForce (strength * Vector3.forward, ForceMode.Impulse);

            gameObject.SetActive (false);
        }
    }
}
