using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This allows us to use and access TMPro objects
using TMPro;

// Added so we can use buttons
using UnityEngine.UI;

// Needed for scene management
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] targetPrefab;

    [SerializeField]
    public GameObject[] targetHalves;

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
    private AudioClip chop, miss, wrong;

    private void Awake()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
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
            GameObject fruit = targetPrefab[choice];
            Instantiate(fruit, StartingPosition(), fruit.transform.rotation);
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
        
        if (lives ==0)
        {
            // Change the game status to inactive
            GameOver();
        }
    }

    public void PlaySound(string fruit)
    {
        if (fruit == "Onion")
        {
            gameAudio.PlayOneShot(wrong);
        }
        else if (fruit == "Miss")
        {
            gameAudio.PlayOneShot(miss);
        }
        else 
        {
            gameAudio.PlayOneShot(chop);
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
        float x = Random.Range(-4.5f, -5f);
        Vector3 location = new Vector3(x, 0, -1);
        return location;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
