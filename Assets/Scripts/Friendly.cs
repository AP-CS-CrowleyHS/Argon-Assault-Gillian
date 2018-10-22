using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour {
    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
    // Use this for initialization
    void Start()
    {
        AddNonTriggerBoxCollider();
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject Fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        Fx.transform.parent = parent;
        Destroy(gameObject);
    }
    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollide = gameObject.AddComponent<BoxCollider>();
        enemyCollide.isTrigger = false;
    }
}
