using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPosition = new Vector3(0, 2, -18);
    private float obstacleY = 2;
    private float obstacleZ = 18;
    private PlayerController playerControllerScript;
    private float finalX;


    private void Awake()
    {
        playerControllerScript = GameObject.Find("Soldier").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacle", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(0, 2);
        if (randomX > 0)
        {
            finalX = 0.5f;
        }
        else
        {
            finalX = -1;
        }
    }
    
    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
            float randomTime = Random.Range(0.75f, 1.5f);

            Instantiate(randomObstacle, new Vector3(finalX, spawnPosition.y, spawnPosition.z), randomObstacle.transform.rotation);
            Invoke("SpawnObstacle", randomTime);
        }
    }
    
}
