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
    float pastVelocity = 0;

    Transform golfball;
    public GameObject mulligen;

    void Start()
    {
        belowMinVelocity = false;

        golfball = GameObject.Find ("Golfball").GetComponent <Transform> ();
        mulligen = GameObject.Find("MulligenObject");
    }

    void Update()
    {
        float currentVelocity;

        currentVelocity = GameObject.Find("Golfball").GetComponent<Rigidbody>().velocity.magnitude;

        belowMinVelocity = currentVelocity < minVelocity && pastVelocity < minVelocity;

        GameObject.Find ("Aim Indicator").GetComponent <MeshRenderer> ().enabled = belowMinVelocity;
        GameObject.Find ("Score Display").GetComponent<MeshRenderer>().enabled = belowMinVelocity;

        pastVelocity = currentVelocity;

        if (belowMinVelocity)
        {
            if (Input.GetMouseButtonDown (0) && !cursorOnUI())
            {
                gameObject.SetActive(false);
                mulligen.GetComponent<MulligenScript>().SavePlayerPosition();
            }

            GameObject.Find ("Golfball").GetComponent <Rigidbody> ().velocity = Vector3.zero;

            golfball.LookAt(cursorLocation());
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

    Vector3 cursorLocation()

    { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }

        return hit.point;
    }
}
