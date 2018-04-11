using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptOne : MonoBehaviour {

    public Vector3 pos;
    public Vector3 playerPos;

    public float speed = 3.0f;
    public float deltaX;

    public GameObject player;
    

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.GetComponent<Transform>().position;
        Debug.Log(playerPos);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move() {

    }
}
