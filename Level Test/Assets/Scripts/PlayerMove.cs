using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform look;

    private Rigidbody playerRB;
    private float speed = 10.0f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Get user input to control left, right, forward and back movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move the player based on key presses
        Vector3 dir = look.right * x + look.forward * z;

        dir *= speed;
        playerRB.AddForce(dir, ForceMode.Force);
    }
}
