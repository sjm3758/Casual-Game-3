using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;
    public float startSpawn;
    public Transform[] spawnPoints;
    public GameObject manager;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        manager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {

        spawnTime = startSpawn;
        spawnTime = spawnTime - manager.GetComponent<ManagerSingleton>().TotalMoney;
        if (spawnTime == 0)
        {
            GameObject.Destroy(this);
        }

       }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
