using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private float speed = 100f;
    private PlayerController playerControllerScript;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Orc").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {


            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
            if (transform.position.z < -250)
            {
                Destroy(gameObject);
            }
        }
    }
}
