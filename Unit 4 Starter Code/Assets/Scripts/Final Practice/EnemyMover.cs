using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody enemyRB;

    private GameObject player;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        // Make the enemy move towards the player
        Vector3 look = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(look * speed);
    }
}
