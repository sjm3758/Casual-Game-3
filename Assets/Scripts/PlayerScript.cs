using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    private Vector3 startingPosition;
    private Vector3 pos;
    private float rot;

    private Vector2 forward; //keeps track of direction it's pointing
    public float speed = 5.0f;
    private float deltaX;
    public float speedCap = 15.0f;

    private Rigidbody2D m_RigidBody;

	// Use this for initialization
	void Start () {
        startingPosition = this.gameObject.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        
        //decelerate to 0
	}

    void Move()
    {
        m_RigidBody = gameObject.GetComponent<Rigidbody2D>();
        //check for move input, add to velocity appropriately
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        pos = this.gameObject.GetComponent<Transform>().position;
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        this.gameObject.GetComponent<Transform>().position = pos;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        //rotate based on moveX
        //rot = moveX * speed * Time.deltaTime;
        //Quaternion turnQuat = Quaternion.Euler(0f, 0f, rot);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, moveY * speed);
    }
}
