using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float jumpForce = 5;
    private float gravityMod = 1f;

    private float horizontal;
    private float speed = 2f;
    public bool gameOver = false;
    private bool isGrounded = true;

    private Animator anim;
    private string jump = "Flip";
    private string run = "Run";
    private string roll = "Roll";
    private string death = "Death3";

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    public ParticleSystem coin;
    public ParticleSystem explosion;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMod;
        anim.SetBool(run, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true && !gameOver)
        {
            if (Input.GetKeyDown(KeyCode.W) && !gameOver)
            {
                anim.SetTrigger(jump);
                playerAudio.PlayOneShot(jumpSound);
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            if (Input.GetKeyDown(KeyCode.S) && !gameOver)
            {
                anim.SetTrigger(roll);
            }
        }
        if (gameOver == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * horizontal * speed);

            if (transform.position.x > 1)
            {
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -1.4f)
            {
                transform.position = new Vector3(-1.4f, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision " + collision.gameObject.tag);

        if (isGrounded == false)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            anim.SetTrigger(death);
            gameOver = true;
            explosion.Play();
            playerAudio.PlayOneShot(explosionSound);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coin.Play();
            playerAudio.PlayOneShot(coinSound);
        }
    }
}
