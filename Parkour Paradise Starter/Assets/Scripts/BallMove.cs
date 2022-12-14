using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private Transform look;

    [SerializeField]
    private GameObject puIndicator;

    private Rigidbody playerRB;
    private float speed = 3.0f;
    private float gravity = 1.0f;

    private float jumpForce = 20f;
    private bool isGrounded = true;
    private bool hasPU = false;

    private GameManager gmScript;
    private MoveSpikes msScript;

    public bool leverOn = false;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        msScript = GameObject.Find("Spikes").GetComponent<MoveSpikes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        // Make the powerup follow the player around
        puIndicator.transform.position = transform.position + new Vector3(0f, 2, 0f);
        Move();
        Jump();
    }

    private void Move()
    {
        if (gmScript.isGameActive == true)
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

    private void Jump()
    {
        // If the space key is pressed and we are on the ground we jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When we collide back with the ground we can jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // If the player collides the enemy and has the powerup, we will knockback the enemy
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Water"))
        {
            transform.position = new Vector3(70.76f, 0.71f, 28.5f);
            gmScript.UpdateLives();
        }
        if (collision.gameObject.CompareTag("Stick"))
        {
            leverOn = true;
        }

        if (hasPU == true)
        {
            jumpForce = 40.0f;
        }

        if (hasPU == false)
        {
            jumpForce = 20.0f;
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            hasPU = true;
            puIndicator.SetActive(true);
            StartCoroutine(CountdownTimer());
        }

        if (collision.gameObject.CompareTag("Button"))
        {
            playerRB.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Trophy"))
        {
            gmScript.GameOver();
        }
    }

    // Controls how long the player has the powerup
    private IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(20);
        hasPU = false;
        puIndicator.SetActive(false);
    }
}
