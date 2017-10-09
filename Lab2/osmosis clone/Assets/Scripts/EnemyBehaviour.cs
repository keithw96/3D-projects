using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyBehaviour : MonoBehaviour {
    Rigidbody2D body;
    float scale;
    Vector3 velocity;
    float startingMass;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        startingMass = body.mass;
        scale = (UnityEngine.Random.Range(0.2f, 2.0f));
        transform.localScale = new Vector3(scale, scale, scale);
        velocity = new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5));
        body.mass = scale;
	}
    // Update is called once per frame
    void LateUpdate () {
        body.AddRelativeForce(velocity);
	}
}
