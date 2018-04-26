using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour {

    private Button btn;
    //private ManagerSingleton manager;
    private Text speedText;

	// Use this for initialization
	void Start () {
        btn = this.gameObject.GetComponent<Button>();
        //manager = GameObject.Find("GameManager").GetComponent<ManagerSingleton>();
        speedText = GameObject.Find("SpeedTxt").GetComponent<Text>();
        btn.onClick.AddListener(UpdateSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        //update the cost text based on manager's cost value
        speedText.text = "Cost: " + ManagerSingleton.Instance.SpeedCost;        
	}

    void UpdateSpeed()
    {
        //only update if player's (manager's) money is enough for purchase
        if (ManagerSingleton.Instance.TotalMoney >= ManagerSingleton.Instance.SpeedCost)
        {
            ManagerSingleton.Instance.PlayerSpeed += 0.5f;
            ManagerSingleton.Instance.TotalMoney -= ManagerSingleton.Instance.SpeedCost;
        }
    }
}
