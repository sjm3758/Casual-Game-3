using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorUp : MonoBehaviour {

    private Button btn;
    //private GameObject manager;
    private Text armorText;

    // Use this for initialization
    void Start () {
        btn = this.gameObject.GetComponent<Button>();
        //manager = GameObject.Find("GameManager");
        armorText = GameObject.Find("ArmorTxt").GetComponent<Text>();
        btn.onClick.AddListener(IncreaseArmor);
    }
	
	// Update is called once per frame
	void Update () {
        //update the cost text based on manager's cost value
        armorText.text = "Cost: " + ManagerSingleton.Instance.ArmorCost;
    }

    void IncreaseArmor()
    {
        //only update if player's (manager's) money is enough for purchase
        if (ManagerSingleton.Instance.TotalMoney >= ManagerSingleton.Instance.ArmorCost)
        {
            ManagerSingleton.Instance.PlayerArmor++;
            ManagerSingleton.Instance.TotalMoney -= ManagerSingleton.Instance.ArmorCost;
            ManagerSingleton.Instance.ArmorClicked++;
        }
    }
}
