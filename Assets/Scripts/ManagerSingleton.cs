using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSingleton : MonoBehaviour {

    //instance of the script
    private static ManagerSingleton _instance;

    //global player variables
    public float playerSpeed;

    public static ManagerSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ManagerSingleton>();
            }
            return _instance;
        }
    }

    //keeps GameManager object across scenes
    private void Awake()
    {
        DontDestroyOnLoad(this);
        //GameObject.Instantiate<GameObject>()
    }

    // Use this for initialization
    void Start () {
        playerSpeed = 5.0f;
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

    public void UpdateSpeed()
    {
        playerSpeed += 0.5f;
    }
}
