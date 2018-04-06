using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour {

    private static ManagerSingleton _instance;

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

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
