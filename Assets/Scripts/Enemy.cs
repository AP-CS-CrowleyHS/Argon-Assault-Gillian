using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
	}
    // Update is called once per frame
    void Update () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollide= gameObject.AddComponent<BoxCollider>();
        //enemyCollide.isTrigger{ };
    }
}
