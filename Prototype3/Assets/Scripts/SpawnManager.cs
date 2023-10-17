using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabe;
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    private float startDelay = 2;
    private float repeateRate = 2;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeateRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
       int  obstacleIndex = Random.Range(0, obstaclePrefabe.Length);
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabe[obstacleIndex], spawnPos, obstaclePrefabe[obstacleIndex].transform.rotation);
        }

    }
}
