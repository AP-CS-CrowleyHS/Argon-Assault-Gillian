using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerKill = 10;
    [SerializeField] int maxHits= 5;

    [SerializeField] AudioSource deathSound;

    ScoreBoard scoreBoard;
	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
    // Update is called once per frame
    void Update () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        if (maxHits <= 1)
        {
            KillEnemy();
            scoreBoard.ScoreHit(scorePerKill);
        }
        else
        {
            maxHits--;
        }
        
    }

    private void KillEnemy()
    {
        deathSound.Play();
        GameObject Fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        Fx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollide= gameObject.AddComponent<BoxCollider>();
        enemyCollide.isTrigger= false;
    }
}
