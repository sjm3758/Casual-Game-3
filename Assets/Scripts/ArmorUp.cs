using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorUp : MonoBehaviour {

    private Button btn;
    public GameObject manager;

    // Use this for initialization
    void Start () {
        btn = this.gameObject.GetComponent<Button>();
        manager = GameObject.Find("GameManager");
        btn.onClick.AddListener(IncreaseArmor);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void IncreaseArmor()
    {
        manager.GetComponent<ManagerSingleton>().ArmorUp();
    }
}
