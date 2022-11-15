using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
      offset = transform.position - player.transform.position;   
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    
    
    // Update is called once per frame
    void Update()
    {
       float inputX = Input.GetAxis ("Horizontal");

       if(inputX != 0)
       {
        transform.Rotate (new Vector3 (0f, 50 * inputX * Time.deltaTime, 0f)); 
       }
    }
}
