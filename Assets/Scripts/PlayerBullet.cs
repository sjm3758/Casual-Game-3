using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed = 6.0f;
	// Use this for initialization
	void Start () {
        Vector2 pos = this.gameObject.GetComponent<Transform>().position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        float h = Mathf.Sqrt(mousePos.x * mousePos.x + mousePos.y * mousePos.y);
        Vector2 bulletAngle = new Vector2((mousePos.x - pos.x) / h, (mousePos.y - pos.y) / h);

        gameObject.GetComponent<Rigidbody2D>().velocity = bulletAngle * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
