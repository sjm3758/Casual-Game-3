using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSingleton : MonoBehaviour {

    //instance of the script
    private static ManagerSingleton _instance;

    //private player variables and money (update these with properties below)
    private float playerSpeed;
    private int playerArmor;
    private int totalMoney;

    public static ManagerSingleton Instance
    {
        get
        {
            //keep instance of this script across scenes
            if (_instance == null)
            {
                GameObject manager = GameObject.Find("GameManager");
                _instance = manager.GetComponent<ManagerSingleton>();
                DontDestroyOnLoad(manager);
            }
            return _instance;
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

    // Use this for initialization
    void Start () {
        _instance = Instance;
        playerSpeed = 4.0f;
        playerArmor = 2;
        totalMoney = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
		/*if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("PlayerTestScene");
        }*/
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("ShopScene");
        }*/
    }
}
