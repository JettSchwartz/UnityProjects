using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private int diff;

    private GameManager gmScript;

    private void Awake()
    {
        button = GetComponent<Button>();
        gmScript = GameObject.Find("SpawnManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gmScript.StartGame(diff);
    }

}
