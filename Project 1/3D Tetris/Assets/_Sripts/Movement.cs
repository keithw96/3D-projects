using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	Vector3 down = new Vector3(0,-1.0f,0);
	Vector3 right = new Vector3 (1, 0, 0);
	Vector3 left = new Vector3 (-1, 0, 0);
	Vector3 rotate = new Vector3(0,0,90);

	float timeSinceLastMove = 0.0f;
	float timeBetweenMoveDown = 1.0f;

	public bool move = true;
	public bool moveL = true;
	public bool moveR = true;

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
	public GameObject jBlock;
    

    // Use this for initialization
    void Start () {
        prefabList.Add(iBlock);
        prefabList.Add(lBlock);
        prefabList.Add(oBlock);
        prefabList.Add(sBlock);
        prefabList.Add(tBlock);
        prefabList.Add(zBlock);
		prefabList.Add(jBlock);
        transform.position.Set(-0.0f, 6, 1);
    }
	void Update()
	{
        if (move)
        {
			if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && collidingRight == false && moveR)
            {
                transform.Translate(right, Space.World);
            }
			else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && collidingLeft == false && moveL)
            {
                transform.Translate(left, Space.World);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                transform.Rotate(rotate);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                transform.Translate(down, Space.World);
            }

        }
        if (!isTriggered && move == false) {

            int blockIndex = UnityEngine.Random.Range(0, 7);
			GameObject clone = Instantiate (prefabList [blockIndex], new Vector3 (0, 6, 1), Quaternion.identity);
			Movement cloneMovement = clone.GetComponent<Movement> ();
			cloneMovement.move = true;
			Debug.Log ("block made " + prefabList [blockIndex]);
			isTriggered = true;
		}
		transform.position.Set (this.transform.position.x - (this.transform.position.x % 1), this.transform.position.y - (this.transform.position.y % 1), this.transform.position.z);

        if (transform.position.y >= 6 && !move)
        {
            SceneManager.LoadScene(3);
        }
    }
	void FixedUpdate (){
		timeSinceLastMove += Time.deltaTime;
		if (timeSinceLastMove > timeBetweenMoveDown && move == true) {
			timeSinceLastMove = 0;
			transform.Translate (down, Space.World);
		}


	}
	void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.name == "Floor") {
			Debug.Log ("touched floor");
            move = false;
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
			transform.Translate( 0.25f, 0, 0, Space.World);
        }

        if (other.gameObject.name == "WallRight")
        {
            transform.Translate(-0.25f, 0, 0, Space.World);
        }
    }
}