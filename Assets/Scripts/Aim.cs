using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    bool aimMode;
    bool coroutineRunning;
    int direction;

    Transform golfball;
    GameObject indicator;

    void Start()
    {
        aimMode = false;
        coroutineRunning = false;
        direction = 0;

        golfball = GetComponentInParent <Transform> ();
        indicator = transform.GetChild (0).gameObject;

        indicator.SetActive (false);
    }

    void Update()
    {
        /*
        *   player sets the direction of the swing
        */
        if (aimMode)
        {
            StartCoroutine (setSwingDirection ());

            // wait until swing direction is set
            while (coroutineRunning);

            /*
            *   destroy this object once direction 
            *   is set
            */
            GameObject.Destroy (this);
        }
        else
        {
            StopCoroutine (setSwingDirection ());
        }

        /*
        *   handles entering aim mode
        */
        if (Input.GetKeyUp(KeyCode.A) && aimMode == false)
        {
            aimMode = true;
        }
    }

    IEnumerator setSwingDirection ()
    {
        coroutineRunning = true;

        indicator.SetActive (true);

        direction += 1;

        if (direction == 360)
        {
            direction = 0;
        }

        golfball.rotation = Quaternion.Euler (0, direction, 0);

        yield return null;

        /*
        *   direction variable stops changing when \
        *   the player presses the spacebar
        */
        if (Input.GetKeyUp (KeyCode.A))
        {
            indicator.SetActive (false);

            coroutineRunning = false;

            StopCoroutine(setSwingDirection ());
        }
    }
}
