using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody playerRB;
    private float jumpForce = 100;
    private float gravityMod = 15f;
    private bool isGrounded = true;
    public bool gameOver = false;

    private Animator anim;
    private string fly = "Fly";
    private string run = "NormalRun";
    private string death = "Death3";

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    public ParticleSystem coin;
    public ParticleSystem explosion;
    public ParticleSystem splatter;

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
        splatter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            splatter.Stop();
            anim.SetBool(run, false);
            anim.SetBool(fly, true);
            playerAudio.PlayOneShot(jumpSound);
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isGrounded == false && !gameOver)
        {


            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                gameOver = true;
                playerAudio.PlayOneShot(explosionSound);
                anim.SetTrigger(death);
                explosion.Play();
                Debug.Log("Game Over!");
            }
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                anim.SetTrigger(death);
                playerAudio.PlayOneShot(explosionSound);
                explosion.Play();
                gameOver = true;
                Debug.Log("Game Over!");
            }
            if (collision.gameObject.CompareTag("Coin"))
            {
                coin.Play();
                playerAudio.PlayOneShot(coinSound);
                Debug.Log("+1 point!");
                
            }
            
        }
    }
}