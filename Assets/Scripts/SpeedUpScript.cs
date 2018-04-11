using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpScript : MonoBehaviour {

    private Button btn;
    public GameObject manager;

	// Use this for initialization
	void Start () {
        btn = this.gameObject.GetComponent<Button>();
        manager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
        btn.onClick.AddListener(UpdateSpeed);
	}

    void UpdateSpeed()
    {
        //manager.GetComponent<ManagerSingleton>().UpdateSpeed();
    }
}
