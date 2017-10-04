using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOBehaviour : MonoBehaviour {
    private Rigidbody2D rd2d;
    float speed;
    private int count;
    public Text countText;
    public Text winText;
    // Use this for initialization
    void Start () {
        rd2d = GetComponent<Rigidbody2D>();
        speed = 2;
        count = 0;
        setCountText();

            }
	
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")* speed;
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;
        rd2d.AddForce(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
            
        }
    }

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        if (count >= 9)
        {
            winText.text = "You Win";
        }
        else
        {
            winText.text = "";
        }
    }

    void setCountText()
    {
        countText.text = "count: " + count.ToString();

    }
}
