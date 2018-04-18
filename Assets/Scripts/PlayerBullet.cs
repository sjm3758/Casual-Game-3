using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed = 8.0f;
    public float endZone = 30.0f;
	// Use this for initialization
	void Start () {
        Vector2 pos = this.gameObject.GetComponent<Transform>().position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        float distX = pos.x - mousePos.x;
        float distY = pos.y - mousePos.y;
        float h = Mathf.Sqrt(mousePos.x * mousePos.x + mousePos.y * mousePos.y);
        Vector2 bulletAngle = new Vector2((mousePos.x - pos.x) / h, (mousePos.y - pos.y) / h);
        //get unit vector of angle
        bulletAngle.Normalize();

        gameObject.GetComponent<Rigidbody2D>().velocity = bulletAngle * speed;
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Sin(distX), -speed * Mathf.Cos(distY));
	}
	
	// Update is called once per frame
	void Update () {
        //destroy when out of bounds
		Vector2 pos = this.gameObject.GetComponent<Transform>().position;
        if(pos.x > endZone || pos.y > endZone || pos.x < -endZone || pos.y < -endZone)
        {
            Destroy(gameObject);
        }
    }

  /*  void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    */
}
