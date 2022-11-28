using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Out of Bounds")
        {
            print("Player out of bounds!");
            GetComponentInChildren<Aim>().mulligen.GetComponent<MulligenScript>().LoadPlayerPosition();
            MulligenScript.used = false;
        }
    }
}
