using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {
    public int rotatonalSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(rotatonalSpeed, rotatonalSpeed, rotatonalSpeed) * Time.deltaTime);
	}
}
