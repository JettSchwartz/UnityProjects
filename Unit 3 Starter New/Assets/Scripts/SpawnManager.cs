using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPosition = new Vector3(-57, 0, 250);
    private PlayerController playerControllerScript;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Orc").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacle", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {


            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
            float randomTime = Random.Range(12f, 4f);
            Instantiate(randomObstacle, spawnPosition, randomObstacle.transform.rotation);
            Invoke("SpawnObstacle", randomTime);

        }
    }
}
