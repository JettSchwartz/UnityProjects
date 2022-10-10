using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coins;
    private Vector3 spawnPosition = new Vector3(-100, 100, 250);
    private PlayerController playerControllerScript;
    private float finalX;
    private float finalZ;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Soldier").GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCoin", 2f);
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
            
        spawnPosition = new Vector3(finalX, Random.Range(0.7f,2f), -18);
    }
    private void SpawnCoin()
    {
        if (playerControllerScript.gameOver == false)
        {

            GameObject randomCoin = coins[Random.Range(0, coins.Length)];
            float randomTime = Random.Range(0.5f,1f);
            Instantiate(randomCoin, spawnPosition, randomCoin.transform.rotation);
            Invoke("SpawnCoin", randomTime);
        }
    }
}
