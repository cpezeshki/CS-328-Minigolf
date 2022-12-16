using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Power : MonoBehaviour
{
    float sensitivity;
    public int minStrength = 1;
    public int maxStrength = 100;
    float strengthFactor = 0.1f;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;
    Vector3 cameraInitialPosition;

    float strength;
    float originalLevel;
    float defaultShake;

    Rigidbody golfball;
    TextMeshPro display;
    Quaternion originalRotation;
    public Camera mainCamera;

    float cameraYPos;

    void Start ()
    {
        sensitivity = (maxStrength - minStrength) / 33;
        strength = minStrength;
        cameraYPos = mainCamera.transform.position.y;
        defaultShake = shakeMagnitude;
        golfball = GetComponentInParent <Rigidbody> ();

    }

    private void OnEnable()
    {
        originalRotation = golfball.transform.rotation;
        strength = minStrength;
    }

    void LateUpdate ()
    {
        float strengthChange;
        float difference;

        difference = 0;

        // prevent spinning on walls while swinging
        golfball.rotation = originalRotation;

        if (!Input.GetMouseButtonUp (0))
        {
            strengthChange = -Input.GetAxis("Mouse Y") * sensitivity;
            display = GameObject.Find("Power Display").GetComponent<TextMeshPro>();

            strength += strengthChange;

            if (strength < minStrength)
            {
                difference = Mathf.Abs (strength - minStrength);
                strength = minStrength;
            }
            else if (strength > maxStrength)
            {
                difference = - Mathf.Abs (strength - maxStrength);
                strength = maxStrength;
            }

            display.text = ((int) ((strength / maxStrength) * 100)).ToString() + "%";
        }
        
        else 
        {
            ShakeIt();
            golfball.AddRelativeForce (strength * strengthFactor * Vector3.forward, ForceMode.Impulse);
            //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, , mainCamera.transform.position.z);
            gameObject.SetActive (false);
        }
    }

    private void ShakeIt()
	{
		cameraInitialPosition = mainCamera.transform.position;
        shakeMagnitude = defaultShake;
        shakeMagnitude = shakeMagnitude * strength;
        shakeMagnitude = shakeMagnitude / 80f;
        Debug.Log(shakeMagnitude);
		InvokeRepeating ("StartCameraShaking", 0f, 0.005f);
		Invoke ("StopCameraShaking", shakeTime);
	}

	void StartCameraShaking()
	{
		float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
		Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
		cameraIntermadiatePosition.y += cameraShakingOffsetY;
		mainCamera.transform.position = cameraIntermadiatePosition;
	}

	void StopCameraShaking()
	{
        cameraInitialPosition.x = mainCamera.transform.position.x;
        cameraInitialPosition.z = mainCamera.transform.position.z;
		CancelInvoke ("StartCameraShaking");
	}
}
