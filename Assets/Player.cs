using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [SerializeField] float posPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float posYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow; float yThrow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch= transform.localPosition.y * posPitchFactor + yThrow * controlPitchFactor;
        float yaw= transform.localPosition.x * posYawFactor;
        float roll= xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); // pitch, yaw, roll
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawNewX = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(rawNewX, -xRange, xRange);

        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawNewY = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(rawNewY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }
}
