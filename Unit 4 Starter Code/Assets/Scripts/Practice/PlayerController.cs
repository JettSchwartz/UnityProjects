using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform look;

    private Rigidbody playerRB;
    private float speed = 3.0f;
    private float gravity = 1.0f;

    private float jumpForce = 5f;
    private bool isGrounded = true;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
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

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
