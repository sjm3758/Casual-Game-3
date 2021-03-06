﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerSingleton : MonoBehaviour {

    //private player variables and money (update these with properties below)
    private float playerSpeed;
    private int playerArmor;
    private int totalMoney;
    private int speedCost;
    private int speedClicked;
    private int armorCost;
    private int armorClicked;
    private int highScore;
    private Text moneyText;
    private Text armorText;
    private Text speedText;
    private Text livesText;

    /*public static ManagerSingleton Instance
    {
        get
        {
            //keep instance of this script across scenes
            if (_instance == null)
            {
                Debug.Log("null");
                GameObject manager = new GameObject();
                manager.name = "Singleton";
                _instance = manager.AddComponent<ManagerSingleton>();
                //GameObject manager = GameObject.Find("GameManager");
                //_instance = manager.GetComponent<ManagerSingleton>();
                DontDestroyOnLoad(manager);
            }
            return _instance;
        }
    }*/

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    //properties for variables
    public float PlayerSpeed
    {
        get
        {
            return playerSpeed;
        }
        set
        {
            playerSpeed = value;
        }
    }

    public int PlayerArmor
    {
        get
        {
            return playerArmor;
        }
        set
        {
            playerArmor = value;
        }
    }

    public int TotalMoney
    {
        get
        {
            return totalMoney;
        }
        set
        {
            totalMoney = value;
        }
    }

    public int ArmorCost
    {
        get
        {
            return armorCost;
        }

        set
        {
            armorCost = value;
        }
    }

    public int SpeedCost
    {
        get
        {
            return speedCost;
        }

        set
        {
            speedCost = value;
        }
    }

    public int SpeedClicked
    {
        get
        {
            return speedClicked;
        }

        set
        {
            speedClicked = value;
        }
    }

    public int ArmorClicked
    {
        get
        {
            return armorClicked;
        }

        set
        {
            armorClicked = value;
        }
    }

    public static ManagerSingleton Instance { get; set; }

    public int HighScore
    {
        get
        {
            return highScore;
        }

        set
        {
            highScore = value;
        }
    }

    // Use this for initialization
    void Start () {
        //these values take precedence over initiated values in player class
        playerSpeed = 4.0f;
        playerArmor = 1;
        speedCost = 10;
        armorCost = 20;
        speedClicked = 1;
        armorClicked = 1;
        HighScore = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //cost never changes, may want to change this later to increasing costs with lower starting values
        speedCost = speedClicked * 10;
        armorCost = armorClicked * 20;

        moneyText = GameObject.Find("Money").GetComponent<Text>();
        moneyText.text = "Money: " + totalMoney;
        //only show some UI on certain scenes (prob should move these to their specific button scripts)
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ShopScene"))
        {
            armorText = GameObject.Find("CurrentArmorText").GetComponent<Text>();
            speedText = GameObject.Find("CurrentSpeedText").GetComponent<Text>();
        }
        else
        {
            armorText = null;
            speedText = null;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PlayerTestScene"))
        {
            livesText = GameObject.Find("Armor").GetComponent<Text>();
        }
        else
        {
            livesText = null;
        }
        if (armorText != null)
        {
            armorText.text = "Current: " + playerArmor;
            speedText.text = "Current: " + playerSpeed;
        }
        if (livesText != null)
        {
            livesText.text = "Health: " + playerArmor;
        }

        //exit the game if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
