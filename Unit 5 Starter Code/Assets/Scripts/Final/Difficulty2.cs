using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty2 : MonoBehaviour
{
    private Button button;

    [SerializeField]
    public int num;

    public int people = 1;

    private GameManager2 gmScript;

    private void Awake()
    {
        button = GetComponent<Button>();

        gmScript = GameObject.Find("SpawnManager").GetComponent<GameManager2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gmScript.StartGame(num);
    }
}
