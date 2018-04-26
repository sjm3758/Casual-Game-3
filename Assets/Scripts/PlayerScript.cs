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
    private float turnSpeed = 3.0f;
    private float deltaX;
    public float speedCap = 15.0f;
    public int health;
    private int maxHealth = 5;
    public int currentLives = 1;
    //for now, will hold base player lives upon game screen load. should not update during game scene
    public int startLives = 1;
    private Vector2 startPos = new Vector2(0,0);
    public GameObject manager;
    public Vector2 velocity;
    public float reloadTime = 10.0f;
    private float reload;

    // Use this for initialization
    void Start () {
        startingPosition = this.gameObject.GetComponent<Transform>().position;
        pos = startingPosition;
        velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        health = maxHealth;
        manager = GameObject.Find("GameManager");
        reload = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        //variable setting isnt working in start, so setting these in update for now
        //techinally only want the first if to call once. manager's armor will act as indicator of lives left. (not sure if there's a need for current lives then? prob not)
        if (manager.GetComponent<ManagerSingleton>().PlayerArmor == startLives)
        {
            startLives = manager.GetComponent<ManagerSingleton>().PlayerArmor;
        }
        else
        {
            currentLives = manager.GetComponent<ManagerSingleton>().PlayerArmor;
        }
        speed = manager.GetComponent<ManagerSingleton>().PlayerSpeed;

        //currentLives = startLives;

        Move();

        //decelerate to 0

        //deplete timer
        if (reload > 0) reload--;
        if (Input.GetMouseButton(0) && reload < 1.0f)
        {
            Fire();
            reload = reloadTime;
        }
        if (currentLives < 1)
        {
            manager.GetComponent<ManagerSingleton>().PlayerArmor = startLives;
            SceneManager.LoadScene("ShopScene");
        }
        /*if (Input.GetKeyDown(KeyCode.L))
        {
            manager.GetComponent<ManagerSingleton>().PlayerArmor--;
        }*/
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
        manager.GetComponent<ManagerSingleton>().PlayerArmor--;
        //respawn the player
        pos = startingPosition;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Enemy")
        {
            Explode();
        }


    }
}
