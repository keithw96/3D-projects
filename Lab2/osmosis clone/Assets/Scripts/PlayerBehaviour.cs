using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
    private Rigidbody2D rd2d;
    float speed;
    float startingMass;
    int count = 0;
    Vector2 movement;
    Vector2 previousMovement;
    public Text countText;
    public Text gameOverText;   
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        startingMass = rd2d.mass;
        speed = 5;
        SetCountText();
    }

    void FixedUpdate()
    {
        previousMovement = movement;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical) * speed;
        rd2d.AddForce(movement);

        if (movement.magnitude < previousMovement.magnitude && rd2d.mass > 0.3f)
        {
            rd2d.mass -= (0.001f * rd2d.mass);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            if (rd2d.mass > other.rigidbody.mass)
            {
                count++;
                other.gameObject.SetActive(false);
                rd2d.mass += 0.3f;
                SetCountText();
            }
            else
            {
                rd2d.gameObject.SetActive(false);
                gameOverText.text = "You Lose";
            }
        }
    }
    private void Update()
    {
        transform.localScale = new Vector3(rd2d.mass, rd2d.mass, rd2d.mass);
        if(count >= 20)
        {
            gameOverText.text = "You Win";
        }
        else
        {
            gameOverText.text = "";
        }
    }

    private void SetCountText()
    {
        countText.text = "Enemies Killed:" + count.ToString();
    }
}
