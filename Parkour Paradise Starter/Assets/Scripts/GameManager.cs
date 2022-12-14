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

    private bool isGameActive = false;

    [SerializeField]
    private GameObject titleScreen;

    public int livesNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
