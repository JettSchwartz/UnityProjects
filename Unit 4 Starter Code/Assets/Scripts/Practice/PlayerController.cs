using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform look;

    [SerializeField]
    private GameObject puIndicator;

    private Rigidbody playerRB;
    private float speed = 3.0f;
    private float gravity = 1.0f;

    private float jumpForce = 5f;
    private bool isGrounded = true;
    private bool hasPu = false;

    private float puStrength = 10f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravity;
        Debug.Log("Destroy the enemies by pushing them into the goals.");
    }

    // Update is called once per frame
    void Update()
    {
        // Make the powerup follow the player around
        puIndicator.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
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
        if (collision.gameObject.CompareTag("Enemy") && hasPu == true)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(away * puStrength, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with the powerup, it will destroy it and turn on hasPu
        if (other.CompareTag("Powerup"))
        {
            Debug.Log("You collected a powerup, you have 7 seconds to use it!");
            Destroy(other.gameObject);
            hasPu = true;
            puIndicator.SetActive(true);
            // Trigger the delay for the powerup
            StartCoroutine(CountdownTimer());
        }
    }

    // Controls how long the player has the powerup
    private IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(7);
        hasPu = false;
        puIndicator.SetActive(false);
    }

}
