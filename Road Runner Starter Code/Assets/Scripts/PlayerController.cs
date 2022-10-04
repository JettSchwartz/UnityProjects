using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float jumpForce = 100;
    private float squatForce = 100;
    private float gravityMod = 15f;
    private bool isGrounded = true;
    public bool gameOver = false;

    private Animator anim;
    private string run = "Run";
    private string jump = "Flip";
    private string roll = "Roll";
    //private string death = "Death3";

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip explosionSound;

    public ParticleSystem splatter;
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
        splatter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !gameOver)
        {
            anim.SetTrigger(jump);
            playerAudio.PlayOneShot(jumpSound);
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
