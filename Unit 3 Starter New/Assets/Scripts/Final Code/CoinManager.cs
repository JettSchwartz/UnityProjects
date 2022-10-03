using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coins;
    private Vector3 spawnPosition = new Vector3(-100, 100, 250);
    private PlayerControls playerControllerScript;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Man1").GetComponent<PlayerControls>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCoin", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = new Vector3(-100, Random.Range(20f, 110f), 250);
    }
    private void SpawnCoin()
    {
        if (playerControllerScript.gameOver == false)
        {

            GameObject randomCoin = coins[Random.Range(0, coins.Length)];
            float randomTime = Random.Range(2f, 4f);
            Instantiate(randomCoin, spawnPosition, randomCoin.transform.rotation);
            Invoke("SpawnCoin", randomTime);

        }
    }
    
}
