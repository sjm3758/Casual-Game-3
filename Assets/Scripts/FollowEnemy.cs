using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour {

    public float speed;
    public Transform target;
    public float range;
    private float distance;
    private Quaternion q;

    // Use this for initialization
    void Start()
    {
        speed = 3f;
        /*Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        q = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }

    // Update is called once per frame
    void Update()
    {


        distance = Vector3.Distance(transform.position, target.position);

        //Chase player - turn
         Vector3 targetDir = target.position - transform.position;
         float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
         q = Quaternion.AngleAxis(angle, Vector3.forward);
         
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        transform.Translate(Vector3.up * Time.deltaTime * speed);

    }
}
