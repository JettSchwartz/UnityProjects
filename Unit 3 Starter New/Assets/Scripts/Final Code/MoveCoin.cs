using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    private float speed = 100;
    private Vector3 originalPosition;
    private float originalZ;
    private PlayerControls playerControllerScript;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Man1").GetComponent<PlayerControls>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalZ = originalPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
            if (transform.position.z < originalZ - 500)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
