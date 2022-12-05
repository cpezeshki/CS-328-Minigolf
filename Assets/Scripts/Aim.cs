using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Aim : MonoBehaviour
{
    public float sensitivity = 3;
    // the velocity threshold before starting a new turn
    public float minVelocity = 0.05f;

    bool belowMinVelocity;
    public float direction;

    Transform golfball;

    public GameObject mulligen;

    void Start()
    {
        belowMinVelocity = false;
        direction = 0;

        golfball = GameObject.Find ("Golfball").GetComponent <Transform> ();
    }

    void Update()
    {
        float currentVelocity;

        currentVelocity = GameObject.Find("Golfball").GetComponent<Rigidbody>().velocity.magnitude;

        belowMinVelocity = currentVelocity < minVelocity;

        GameObject.Find ("Aim Indicator").GetComponent <MeshRenderer> ().enabled = belowMinVelocity;
        GameObject.Find ("Score Display").GetComponent<MeshRenderer>().enabled = belowMinVelocity;

        if (belowMinVelocity)
        {
            if (Input.GetMouseButtonDown (0) && !cursorOnUI())
            {
                gameObject.SetActive(false);
                mulligen.GetComponent<MulligenScript>().SavePlayerPosition();
            }

            GameObject.Find ("Golfball").GetComponent <Rigidbody> ().velocity = Vector3.zero;

            direction += Input.GetAxis ("Mouse X") * sensitivity;

            golfball.rotation = Quaternion.Euler (0, direction, 0);
        }
    }

    // https://forum.unity.com/threads/how-to-detect-if-mouse-is-over-ui.1025533/#post-6642844
    bool cursorOnUI()
    {
        int layer = LayerMask.NameToLayer("UI");
        List<RaycastResult> raycasts = raycastAtCursor();

        for (int index = 0; index < raycasts.Count; index += 1)
        {
            RaycastResult currentRaycast = raycasts[index];

            if (currentRaycast.gameObject.layer == layer)
            {
                return true;
            }
        }

        return false;
    }

    List<RaycastResult> raycastAtCursor()
    {
        List<RaycastResult> raycasts = new();
        PointerEventData data = new(EventSystem.current);

        data.position = Input.mousePosition;

        EventSystem.current.RaycastAll(data, raycasts);

        return raycasts;
    }
}
