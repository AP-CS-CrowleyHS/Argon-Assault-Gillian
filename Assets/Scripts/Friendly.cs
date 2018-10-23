using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour {
    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;

    [SerializeField] AudioSource deathSound;
    // Use this for initialization
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) //somehow make collision work
    {
        deathSound.Play();
        GameObject Fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        Fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
