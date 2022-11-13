// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     public GameObject player;

//     private Vector3 offset;

//     // Start is called before the first frame update
//     void Start()
//     {
//         offset = transform.position - player.transform.position;
//     }

//     // Update is called once per frame
//     void LateUpdate()
//     {
//         transform.position = player.transform.position + offset;

//         if (Input.GetKeyUp (KeyCode.Space))
//         {
//             player.GetComponent <Rigidbody> ().AddForce (-1, 0, 0, ForceMode.Impulse);
//         }
//     }
// }
