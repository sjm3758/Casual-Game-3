using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    private Vector3 startingPosition;
    private Vector3 pos;

    public float speed = 5.0f;
    private float deltaX;
    public float speedCap = 15.0f;

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
        //check for move input, add to velocity appropriately
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        pos = this.gameObject.GetComponent<Transform>().position;
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        this.gameObject.GetComponent<Transform>().position = pos;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, moveY * speed);
    }

    void Fire()
    {
        //get mouseDown for fire button
        //get mousePosition, use it to calculate bullet velocity
        //create bullet in front of player with velocity
    }

    void Explode()
    {
        //destroy the player object
        //deduct a life
        //respawn the player
        
    }
}
