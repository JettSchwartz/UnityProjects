using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    
    private int waveCount = 1;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        // Find how many enemies are in my scene
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveCount = waveCount + 1;
            SpawnEnemy(waveCount);
        }
    }

    private void SpawnEnemy(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemyPrefab, NewPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Generates a random position to spawn enemies
    private Vector3 NewPosition()
    {
        float spawnX = Random.Range(-9, 9);
        float spawnZ = Random.Range(-6, 6);
        Vector3 randomPosition = new Vector3(spawnX, 3, spawnZ);
        return randomPosition;
    }
}
