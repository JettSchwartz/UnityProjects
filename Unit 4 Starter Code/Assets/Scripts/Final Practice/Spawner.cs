using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject puPrefab;

    [SerializeField]
    private GameObject enemy2;

    private int waveCount = 1;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveCount);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        // Find how many enemies are in my scene
        enemyCount = FindObjectsOfType<MainEnemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemy2();
            Debug.Log("Congratulations, you defeated " + waveCount + " enemies");
            waveCount = waveCount + 1;
            SpawnEnemy(waveCount-2);
            SpawnPowerup();
        }
    }

    // This method will spawn enemies each time they are destroyed
    private void SpawnEnemy(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemyPrefab, NewPosition(), enemyPrefab.transform.rotation);

        }
    }

    // Spawn running enemeies each at beginning of each wave
    private void SpawnEnemy2()
    {
        Instantiate(enemy2, NewPosition(), enemy2.transform.rotation);
    }

    // Spawn a powerup at the beginning of each wave
    private void SpawnPowerup()
    {
        Instantiate(puPrefab, NewPosition() - new Vector3(0, 3f, 0f), puPrefab.transform.rotation);
    }


    // Generates a random position to spawn enemies
    private Vector3 NewPosition()
    {
        float spawnX = Random.Range(-9, 9);
        float spawnZ = Random.Range(-6, 6);
        Vector3 randomPosition = new Vector3(spawnX, 3f, spawnZ);
        return randomPosition;
    }
}
