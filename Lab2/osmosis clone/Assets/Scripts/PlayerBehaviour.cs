using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    private Rigidbody2D rd2d;
    float speed;
    // Use this for initialization
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        speed = 5;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;
        rd2d.AddForce(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();

        if (other.gameObject.CompareTag("Enemies"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
       
    }
}
