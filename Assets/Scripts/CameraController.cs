using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float golfballRotation = player.transform.rotation.y;

        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler (0, golfballRotation, 0);

        // if(inputX != 0)
        // {
        //     transform.RotateAround(player.transform.position, Vector3.up, 20 * Time.deltaTime);
        // }
        
        // if (Input.GetKeyUp(KeyCode.RightArrow))
        // {
        //     transform.Rotate (new Vector3 (0f, inputX * Time.deltaTime, 0f));
        // }
        // if (Input.GetKeyUp(KeyCode.LeftArrow))
        // {
        //     transform.Rotate (new Vector3 (0f, 5 * Time.deltaTime, 0f));
        // }
    }
}
// var target:transform;
 
// function Update(){
//     transform.LookAt(target);
//     transform.Translate(Vector3.right * Time.deltaTime);
// }