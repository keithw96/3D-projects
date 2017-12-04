using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetection : MonoBehaviour {
	Rigidbody parent;
	// Use this for initialization
	void Start () {
		parent = GetComponentInParent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Movement a = GetComponentInParent<Movement> ();
		Debug.DrawRay (this.transform.position, Vector3.down * 1.0f);
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit,1.0f)) {
			if (hit.collider.tag == "Cube" && hit.rigidbody != parent) {
				a.move = false;
			}
		}
			
		RaycastHit hitL;
		if (Physics.Raycast (this.transform.position, Vector3.left, out hitL, 1.0f)) {
			if (hitL.collider.tag == "Cube" && hitL.rigidbody != parent) {
				a.moveL = false;
			}
			else {
				a.moveL = true;	
			}
		} 

		RaycastHit hitR;
		if (Physics.Raycast (this.transform.position, Vector3.right, out hitR, 1.0f)) {
			if (hitR.collider.tag == "Cube" && hitR.rigidbody != parent) {
				a.moveR = false;
			}
			else {
				a.moveR = true;
			}
		} 
	}
}
