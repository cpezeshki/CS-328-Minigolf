using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    bool powerMode;
    bool reachedMaxPower;
    bool coroutineRunning;
    int strength;

    Vector3 power;
    Rigidbody golfball;
    GameObject indicator;

    void Start()
    {
        powerMode = false;
        reachedMaxPower = false;
        coroutineRunning = false;
        strength = 0;

        power = Vector3.zero;
        golfball = GetComponentInParent <Rigidbody> ();
        indicator = transform.GetChild(0).gameObject;

        indicator.SetActive(false);
    }

    void Update()
    {
        /*
        *   player sets the power of the swing
        */
        if (powerMode)
        {
            StartCoroutine (setSwingPower ());

            // wait until swing power is set
            while (coroutineRunning);

            power = new Vector3 (strength, 0, 0);

            golfball.AddRelativeForce (power, ForceMode.Impulse);

            /*
            *   destroy this object once swing is 
            *   finished
            */
            GameObject.Destroy(this);
        }
        else
        {
            StopCoroutine (setSwingPower ());
        }

        /*
        *   handles entering power mode 
        */
        if (Input.GetKeyUp (KeyCode.S) && powerMode == false)
        {
            powerMode = true;
        }
    }

    IEnumerator setSwingPower ()
    {
        Vector3 indicatorPosition = indicator.transform.position;

        coroutineRunning = true;

        indicator.SetActive(true);

        if (strength == 0)
        {
            reachedMaxPower = false;
        }

        if (strength == 100)
        {
            reachedMaxPower = true;
        }

        if (strength < 100 && reachedMaxPower == false)
        {
            strength += 1;

            indicatorPosition.y += 0.002f;
        }

        if (strength > 0 && reachedMaxPower == true)
        {
            strength -= 1;

            indicatorPosition.y -= 0.002f;
        }

        yield return null;

        /*
        *   power variable stops changing when the 
        *   player presses the spacebar
        */
        if (Input.GetKeyUp (KeyCode.S))
        {
            indicator.SetActive(false);

            coroutineRunning = false;

            StopCoroutine (setSwingPower ());
        }
    }
}
