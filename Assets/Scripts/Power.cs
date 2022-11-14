using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public int minStrength = 1;
    public int maxStrength = 100;
    public float strengthFactor = 0.1f;

    bool increasing;
    int strength;

    Rigidbody golfball;
    Vector3 originalIndicatorPosition;

    void Start ()
    {
        increasing = true;
        strength = minStrength;

        golfball = GetComponentInParent <Rigidbody> ();
    }

    void Update ()
    {
        Transform indicatorLevel = GameObject.Find ("Power Indicator").GetComponent <Transform> ();

        if (increasing)
        {
            strength += 1;
            indicatorLevel.position += new Vector3 (0, 0.002f);
        }
        else
        {
            strength -= 1;
            indicatorLevel.position -= new Vector3 (0, 0.002f);
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
            golfball.AddRelativeForce (strength * strengthFactor * Vector3.forward, ForceMode.Impulse);

            gameObject.SetActive (false);
        }
    }
}
