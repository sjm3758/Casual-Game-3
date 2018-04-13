using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSingleton : MonoBehaviour {

    //instance of the script
    private static ManagerSingleton _instance;

    //private player variables and money (update these with functions below)
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

    // Use this for initialization
    void Start () {
        playerSpeed = 5.0f;
        playerArmor = 1;
        totalMoney = 0;
        _instance = Instance;
	}
	
	// Update is called once per frame
	void Update () {
        
		if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("PlayerTestScene");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("ShopScene");
        }
    }

    //public functions to update variables
    public void SpeedUp()
    {
        playerSpeed++;
    }

    public void ArmorUp()
    {
        playerArmor++;
    }
}
