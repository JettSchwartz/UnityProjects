using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove2 : MonoBehaviour
{
    private Rigidbody targetRB;

    private GameManager2 gmScript;

    [SerializeField]
    private int points;

    private void Awake()
    {
        targetRB = GetComponent<Rigidbody>();
        gmScript = GameObject.Find("SpawnManager").GetComponent<GameManager2>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 5 * Time.deltaTime,Space.World);
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
            // When the item is not an onion, the player is penalized and loses a life
           
            gmScript.UpdateScore2();
            
        }
    }

    // Checks to see which prefab has been chopped
    private void OnMouseDown()
    {
            gmScript.UpdateScore();
            // Pass the fruit that has been clicked on
            Destroy(gameObject);
    }
}   
