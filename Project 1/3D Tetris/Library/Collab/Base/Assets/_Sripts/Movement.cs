using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	Vector3 down = new Vector3(0,-1.0f,0);
	Vector3 right = new Vector3 (1, 0, 0);
	Vector3 left = new Vector3 (-1, 0, 0);
	Vector3 rotate = new Vector3(0,0,90);

	float timeSinceLastMove = 0.0f;
	float timeBetweenMoveDown = 1.0f;

	public bool move = true;
    bool collidingRight = false;
    bool collidingLeft = false;
    bool isTriggered = false;

    List<GameObject> prefabList = new List<GameObject>();
    public GameObject iBlock;
    public GameObject lBlock;
    public GameObject oBlock;
    public GameObject sBlock;
    public GameObject tBlock;
    public GameObject zBlock;

   

    // Use this for initialization
    void Start () {
        prefabList.Add(iBlock);
        prefabList.Add(lBlock);
        prefabList.Add(oBlock);
        prefabList.Add(sBlock);
        prefabList.Add(tBlock);
        prefabList.Add(zBlock);
        transform.position.Set(-0.83f, 6, 1);

    }
	void Update()
	{
		if (move) {
            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && collidingRight == false) {
                transform.Translate(right, Space.World);
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && collidingLeft == false)
            {
				transform.Translate (left, Space.World);
			} 
			else if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
				transform.Rotate (rotate);
			}
		}
	}
	// Update is called once per frame
	void LateUpdate () {
		timeSinceLastMove += Time.deltaTime;
		if (timeSinceLastMove > timeBetweenMoveDown && move == true) {
			timeSinceLastMove = 0;
			transform.Translate (down, Space.World);
		}
	}
	void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.name == "Floor" || other.gameObject.name == "I-Block"
            || other.gameObject.name == "L-Block" || other.gameObject.name == "O-Block"
            || other.gameObject.name == "S-Block" || other.gameObject.name == "T-Block"
            || other.gameObject.name == "Z-Block") {
            move = false;

            if (!isTriggered)
            {
                int blockIndex = UnityEngine.Random.Range(0, 6);
                Instantiate(prefabList[blockIndex]);
                Debug.Log("block made" + prefabList[blockIndex]);
                isTriggered = true;
            }
           
        } 

        if(other.gameObject.name == "WallLeft")
        {
            collidingLeft = true;
        }

        if (other.gameObject.name == "WallRight")
        {
            collidingRight = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name == "WallLeft")
        {
            collidingLeft = false;
        }

        if(other.gameObject.name == "WallRight")
        {
            collidingRight = false;
        }
    }


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "WallLeft")
        {
            transform.Translate(0.1f, 0, 0, Space.World);
        }

        if (other.gameObject.name == "WallRight")
        {
            transform.Translate(-0.1f, 0, 0, Space.World);
        }
    }
}