using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float forceFactor = 200f;
    List<Rigidbody> ball = new List<Rigidbody>();
    Transform magnetPoint;
    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if(DialogueManager.magnetHole == true)
        {
            foreach (Rigidbody b in ball)
            {
                b.AddForce((magnetPoint.position - b.position) * forceFactor * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggering");
        if(other.CompareTag("Player"))
        {
            ball.Add(other.GetComponent<Rigidbody>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ball.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
