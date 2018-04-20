using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour {

    private Button btn;
    private GameObject manager;
    private Text speedText;

	// Use this for initialization
	void Start () {
        btn = this.gameObject.GetComponent<Button>();
        manager = GameObject.Find("GameManager");
        speedText = GameObject.Find("SpeedText").GetComponent<Text>();
        btn.onClick.AddListener(UpdateSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        //update the cost text based on manager's cost value
        speedText.text = "Cost: " + manager.GetComponent<ManagerSingleton>().SpeedCost;
	}

    void UpdateSpeed()
    {
        //only update if player's (manager's) money is enough for purchase
        if (manager.GetComponent<ManagerSingleton>().TotalMoney >= manager.GetComponent<ManagerSingleton>().SpeedCost)
        {
            manager.GetComponent<ManagerSingleton>().PlayerSpeed += 0.5f;
            manager.GetComponent<ManagerSingleton>().TotalMoney -= manager.GetComponent<ManagerSingleton>().SpeedCost;
        }
    }
}
