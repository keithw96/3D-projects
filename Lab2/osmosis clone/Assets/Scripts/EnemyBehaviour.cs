using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    float scale;
    Vector3 velocity;
	// Use this for initialization
	void Start () {
        scale = (Random.Range(0.2f, 1.0f));
        transform.localScale = new Vector3(scale, scale, scale);
        velocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
	}
    // Update is called once per frame
    void Update () {
        transform.position += velocity * Time.deltaTime;
	}
}
