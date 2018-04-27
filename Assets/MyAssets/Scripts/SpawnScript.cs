using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject RedBallPrefab;
    public GameObject GreenBallPrefab;
    public GameObject PurpleBallPrefab;
    private float timer;
    float SpawnDelay = 5.0f;
    public bool SnakeIsDead = false;
    int randomSpawn;
	// Use this for initialization
	void Start () {
        timer = SpawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(SnakeIsDead == false)
        {
            if(timer<0)
            {
                Spawn();
                timer = SpawnDelay;
            }
        }

        if(GameObject.FindWithTag("GreenBall") == null)
        {
            randomSpawn = UnityEngine.Random.Range(0, 2);
            if (randomSpawn == 0)
            {
                Instantiate(GreenBallPrefab, Spawn2.transform.position, Spawn2.transform.rotation);
            }
            else if (randomSpawn == 1)
            {
                Instantiate(GreenBallPrefab, Spawn1.transform.position, Spawn1.transform.rotation);
            }
        }
        if (GameObject.FindWithTag("RedBall") == null)
        {
            randomSpawn = UnityEngine.Random.Range(0, 2);
            if (randomSpawn == 0)
            {
                Instantiate(RedBallPrefab, Spawn2.transform.position, Spawn2.transform.rotation);
            }
            else if (randomSpawn == 1)
            {
                Instantiate(RedBallPrefab, Spawn1.transform.position, Spawn1.transform.rotation);
            }
        }
        if (GameObject.FindWithTag("PurpleBall") == null && GameObject.FindWithTag("Snake")==null)
        {
            randomSpawn = UnityEngine.Random.Range(0, 2);
            if (randomSpawn == 0)
            {
                Instantiate(PurpleBallPrefab, Spawn2.transform.position, Spawn2.transform.rotation);
            }
            else if (randomSpawn == 1)
            {
                Instantiate(PurpleBallPrefab, Spawn1.transform.position, Spawn1.transform.rotation);
            }
        }
    }

    private void Spawn()
    {
        randomSpawn = UnityEngine.Random.Range(0, 2);
        if(randomSpawn == 0)
        {
            Instantiate(PurpleBallPrefab, Spawn2.transform.position, Spawn2.transform.rotation);
        }
        else if(randomSpawn == 1)
        {
            Instantiate(PurpleBallPrefab, Spawn1.transform.position, Spawn1.transform.rotation);
        }
    }
}
