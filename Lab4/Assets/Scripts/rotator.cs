using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
    Rigidbody bd;
	// Use this for initialization
	void Start () {
        bd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        bd.transform.Rotate(0.1f, 0.1f, 0);
	}
}
