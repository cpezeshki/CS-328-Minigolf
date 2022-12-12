using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Power : MonoBehaviour
{
    float sensitivity;
    public int minStrength = 1;
    public int maxStrength = 100;
    float strengthFactor = 0.1f;

    float strength;
    float originalLevel;

    Rigidbody golfball;
    TextMeshPro display;
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
        strength = minStrength;
    }

    void Update ()
    {
        float strengthChange;
        float difference;

        difference = 0;

        // prevent spinning on walls while swinging
        golfball.rotation = originalRotation;

        if (!Input.GetMouseButtonUp (0))
        {
            strengthChange = -Input.GetAxis("Mouse Y") * sensitivity;
            display = GameObject.Find("Power Display").GetComponent<TextMeshPro>();

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

            display.text = ((int) ((strength / maxStrength) * 100)).ToString() + "%";
        }
        
        else 
        {
            golfball.AddRelativeForce (strength * strengthFactor * Vector3.forward, ForceMode.Impulse);

            gameObject.SetActive (false);
        }
    }
}
