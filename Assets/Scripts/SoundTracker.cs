using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTracker : MonoBehaviour
{

    public AudioSource[] soundFX;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            soundFX[0].Play();
        }
    }
}
