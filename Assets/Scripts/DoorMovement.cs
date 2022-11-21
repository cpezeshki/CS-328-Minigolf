using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    float timer = 0f;
    float speed = 0.02f;
    int phase = 0;
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer>1f)
        {
            phase++;
            phase %= 4;
            timer = 0f;
        }

        switch(phase)
        {
            case 0:
                transform.Translate(0f, speed * (1 - timer), 0f);
                break;
            case 1:
                transform.Translate(0f, -speed * timer, 0f);
                break;
            case 2:
                transform.Translate(0f, -speed * (1 - timer), 0f);
                break;
            case 3:
                transform.Translate(0f, speed * timer, 0f);
                break;
        }
    }
}

