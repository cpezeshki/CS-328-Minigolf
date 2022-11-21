using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float sensitivity = 3;
    public int minStrength = 1;
    public int maxStrength = 100;
    public float strengthFactor = 0.1f;

    public GameObject Aim;

    float strength;

    Rigidbody golfball;

    void Start ()
    {
        strength = minStrength;

        golfball = GetComponentInParent <Rigidbody> ();
    }

    void Update ()
    {
        float strengthChange;
        float difference;

        Transform indicatorLevel;
        golfball.rotation = Quaternion.Euler(0, Aim.GetComponent <Aim> ().direction, 0);

        difference = 0;

        if (!Input.GetMouseButtonUp (0))
        {
            strengthChange = -Input.GetAxis("Mouse Y") * sensitivity;
            indicatorLevel = GameObject.Find("Power Indicator").GetComponent<Transform>();

            strength += strengthChange;

            if (strength < minStrength)
            {
                difference = Mathf.Abs (strength - minStrength);
                strength = minStrength;
            }
            else if (strength > maxStrength)
            {
                difference = - Mathf.Abs (strength - maxStrength);
                strength = maxStrength;
            }

            indicatorLevel.position += new Vector3(0, 0.002f * (strengthChange + difference), 0);
        }
        
        else 
        {
            golfball.AddRelativeForce (strength * strengthFactor * Vector3.forward, ForceMode.Impulse);

            gameObject.SetActive (false);
        }
    }
}
