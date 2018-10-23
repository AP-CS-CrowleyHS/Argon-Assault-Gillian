using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 3f;
    [Tooltip("Fx prefab on player")] [SerializeField] GameObject deathFx;
    [SerializeField] AudioSource deathSound;
    private void OnTriggerEnter(Collider other)
    {
        deathSound.Play();
        StartDeathSequence();
        deathFx.SetActive(true);
        Invoke("ReloadsLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
    private void ReloadsLevel() //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
