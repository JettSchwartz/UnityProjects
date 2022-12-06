using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] targetPrefab;

    [SerializeField]
    public GameObject[] spawn;

    private float spawnRate = 3.0f;

    private int score, lives;

    // This adds TMPro object
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI livesText, gameOverText;

    // This adds a UI button
    [SerializeField]
    private Button restartButton;

    private Coroutine startFruit;

    // This will keep track of wheter the game is over or not
    private bool isGameActive = true;

    private AudioSource gameAudio;

    [SerializeField]
    private AudioClip click, miss, wrong;

    [SerializeField]
    private GameObject titleScreen;

    public int length;

    private void Awake()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    // This will run after the difficulty is chosen
    public void StartGame(int numOfEnemies)
    {
        // Hide the title screen
        titleScreen.gameObject.SetActive(false);

        // Based on number, the enemies will be set
        length = numOfEnemies;

        score = 0;
        lives = 3;
        startFruit = StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int choice = Random.Range(0, targetPrefab.Length);
            GameObject person = targetPrefab[choice];


            // Change size of fruit
            person.transform.localScale = new Vector3(2, 2, 2);

            Instantiate(person, StartingPosition(), person.transform.rotation);
        }
    }

    // This weill adjust score
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if (lives == 0)
        {
            // Change the game status to inactive
            GameOver();
        }
    }

    public void PlaySound(string person)
    {
        if (person == "ghost")
        {
            gameAudio.PlayOneShot(wrong);
        }
        else if (person == "Miss")
        {
            gameAudio.PlayOneShot(miss);
        }
        else
        {
            gameAudio.PlayOneShot(click);
        }
    }
    private void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        StopCoroutine(startFruit);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private Vector3 StartingPosition()
    {
        int choice = Random.Range(0, spawn.Length);
        GameObject grave = spawn[choice];
        Vector3 location = new Vector3(grave.transform.position.x, grave.transform.position.y, 1.8f);
        return location;
    }
    
    private void Update()
    {
        
    }

}
