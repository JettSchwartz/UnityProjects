using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI RemainingCoinsText;

    [SerializeField]
    private TextMeshProUGUI livesText, gameOverText;
    
    [SerializeField]
    private Button restartButton;

    public bool isGameActive = false;

    [SerializeField]
    private GameObject titleScreen;

    public int livesNum;
    public int coinsNum;

    private void Awake()
    {
        coinsNum = 10;
        RemainingCoinsText.text = "Remaining Coins: " + coinsNum;
        livesText.text = "Lives Left: " + livesNum;
    }
    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        livesText.gameObject.SetActive(true);
        RemainingCoinsText.gameObject.SetActive(true);
        isGameActive = true;
        livesNum = difficulty;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateCoins()
    {
        coinsNum--;
        RemainingCoinsText.text = "Remaining Coins: " + coinsNum;

        if (coinsNum == 0)
        {
            // Change the game status to inactive
            GameOver();
        }
    }

    public void UpdateLives()
    {
        livesNum--;
        livesText.text = "Lives Left: " + livesNum;

        if (livesNum == 0)
        {
            // Change the game status to inactive
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
