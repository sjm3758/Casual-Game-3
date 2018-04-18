using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    private Vector3 startingPosition;
    private Vector3 pos;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float speed = 4.0f;
    private float turnSpeed = 3.0f;
    private float deltaX;
    public float speedCap = 15.0f;
    public int health;
    private int maxHealth = 5;
    private int currentLives;
    private int startLives;
    private Vector2 startPos = new Vector2(0,0);
    private GameObject manager;
    public Vector2 velocity;

    // Use this for initialization
    void Start () {
        startingPosition = this.gameObject.GetComponent<Transform>().position;
        pos = startingPosition;
        velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        health = maxHealth;
        manager = GameObject.Find("GameManager");
        startLives = manager.GetComponent<ManagerSingleton>().PlayerArmor;
        currentLives = startLives;
        //speed = manager.GetComponent<ManagerSingleton>().PlayerSpeed;

	}
	
	// Update is called once per frame
	void Update () {
        Move();

        //decelerate to 0
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (currentLives < 1)
        {
            //SceneManager.LoadScene("ShopScene");
        }
	}

    void Move()
    {
        //check for move input, add to velocity appropriately
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        pos = this.gameObject.GetComponent<Transform>().position;
        //velocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        this.gameObject.GetComponent<Transform>().position = pos;
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, moveY * speed);
        //this.gameObject.GetComponent<Transform>().position += this.gameObject.GetComponent<Transform>().up * moveY * speed * Time.deltaTime;
        //this.gameObject.GetComponent<Transform>().Rotate(0, 0, -moveX * turnSpeed);
        //this.gameObject.GetComponent<Transform>().Rotate

        //look at the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        float angleRad = Mathf.Atan2(mousePos.y - pos.y, mousePos.x - pos.x);
        float angle = (180 / Mathf.PI) * angleRad;
        this.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle - 90);
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
        currentLives--;
        //respawn the player
        pos = startingPosition;
    }
}
