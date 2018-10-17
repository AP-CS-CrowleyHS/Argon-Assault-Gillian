using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
	}
    // Update is called once per frame
    void Update () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        GameObject Fx= Instantiate(DeathFX, transform.position, Quaternion.identity);
        Fx.transform.parent= parent;
        Destroy(gameObject);
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollide= gameObject.AddComponent<BoxCollider>();
        enemyCollide.isTrigger= false;
    }
}
