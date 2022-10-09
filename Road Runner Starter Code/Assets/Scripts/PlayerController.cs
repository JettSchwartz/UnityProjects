using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 2f;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
