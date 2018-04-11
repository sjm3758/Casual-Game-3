using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    float speed;
    Vector2 forward;
    Vector2 maxPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

	// Use this for initialization
	void Start () {
        speed = 8.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        if(transform.position.y > maxPos.y)
        {
            Destroy(gameObject);
        }
	}
}
