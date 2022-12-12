using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    float sensitivity;
    public int minStrength = 1;
    public int maxStrength = 100;
    float strengthFactor = 0.1f;

    float strength;
    float originalLevel;

    Rigidbody golfball;
    Transform indicatorLevel;
    Quaternion originalRotation;

    void Start ()
    {
        sensitivity = (maxStrength - minStrength) / 33;
        strength = minStrength;

        golfball = GetComponentInParent <Rigidbody> ();
    }

    private void OnEnable()
    {
        originalRotation = golfball.transform.rotation;
        originalLevel = indicatorLevel.transform.localPosition.y;
        strength = minStrength;
        indicatorLevel.position += new Vector3(0, originalLevel, 0);
    }

    void Update ()
    {
        float strengthChange;
        float difference;
        float indicatorScale;

        difference = 0;

        // prevent spinning on walls while swinging
        golfball.rotation = originalRotation;

        if (!Input.GetMouseButtonUp (0))
        {
            strengthChange = -Input.GetAxis("Mouse Y") * sensitivity;
            indicatorLevel = GameObject.Find("Power Indicator").GetComponent<Transform>();
            indicatorScale = maxStrength / 100;

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

            indicatorLevel.position += new Vector3(0, 0.002f * ((strengthChange + difference) / indicatorScale), 0);
        }
        
        else 
        {
            golfball.AddRelativeForce (strength * strengthFactor * Vector3.forward, ForceMode.Impulse);

            gameObject.SetActive (false);
        }
    }
}
