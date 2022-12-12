using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public float sensitivity = 100;

    private Vector3 offset;
    private GameObject golfball;

    // Start is called before the first frame update
    void Start()
    {
        golfball = GameObject.Find("Golfball");

        offset = transform.position - golfball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(1) && rotation != 0)
        {
            transform.Rotate(new Vector3(0f, sensitivity * rotation * Time.deltaTime, 0f));
        }
    }

    private void LateUpdate()
    {
        transform.position = golfball.transform.position + offset;
    }
}
