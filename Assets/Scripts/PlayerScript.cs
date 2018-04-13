using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    private Vector3 startingPosition;
    private Vector3 pos;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 4.0f;
    public float turnSpeed = 6.0f;
    private float deltaX;
    public float speedCap = 15.0f;
    public int health;
    private int maxHealth = 5;
    private int lives;
    public int startLives = 3;
    private Vector2 startPos = new Vector2(0,0);

	// Use this for initialization
	void Start () {
        startingPosition = this.gameObject.GetComponent<Transform>().position;
        pos = startingPosition;
        health = maxHealth;
        lives = startLives;
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        //decelerate to 0
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
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
        // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, moveY * speed);
        this.gameObject.GetComponent<Transform>().position += this.gameObject.GetComponent<Transform>().up * moveY * speed * Time.deltaTime;
        this.gameObject.GetComponent<Transform>().Rotate(0, 0, -moveX * turnSpeed);
    }

    void Fire()
    {
        //get mouseDown for fire button
        //get mousePosition, use it to calculate bullet velocity
        
        //create bullet in front of player with velocity
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(bullet, 2.0f);
    }

    void Explode()
    {
        //deduct a life
        lives--;
        //respawn the player
        pos = startingPosition;
    }
}
