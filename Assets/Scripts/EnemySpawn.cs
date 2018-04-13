using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {

       }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
