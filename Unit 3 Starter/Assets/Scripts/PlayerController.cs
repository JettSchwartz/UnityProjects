using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float jumpForce = 100;
    private float gravityMod = 15f;
    private bool isGrounded = true;
    public bool gameOver = false;

    private Animator anim;
    private string jump = "FunJump";
    private string run = "FunRun";
    private string death = "Death3";

    private void Awake()
    {
        playerRB = GetComponent< Rigidbody > ();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMod;
        anim.SetBool(run,true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !gameOver)
        {
            anim.SetTrigger(jump);
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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            anim.SetTrigger(death);
            gameOver = true;
            Debug.Log("Game Over!");
        }

        
    }
}
