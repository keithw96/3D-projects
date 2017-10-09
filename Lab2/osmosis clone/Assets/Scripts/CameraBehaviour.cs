using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //moves the camera as if it is a child of player
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
