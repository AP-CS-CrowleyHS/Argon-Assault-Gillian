using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 50f;
    [Tooltip("In m")] [SerializeField] float xRange = 7f;
    [Tooltip("In m")] [SerializeField] float yRange = 4.5f;
    [Header("Screen Position")]
    [SerializeField] float posPitchFactor = -5f;
    [SerializeField] float posYawFactor = 5f;
    [Header("Control- Throw")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    [Header("Guns")]
    [SerializeField] GameObject[] guns;

    float xThrow; float yThrow;
    bool controlsEnabled = true;
    
    // Update is called once per frame
    void Update ()
    {
        if (controlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
        
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool activate)
    {
        foreach (GameObject gun in guns)
        {
            
            gun.SetActive(activate);
        }
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

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawNewX = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(rawNewX, -xRange, xRange);

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawNewY = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(rawNewY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }
    private void OnPlayerDeath() //called by Collsion Handler
    {
        controlsEnabled = false;
    }
}
