using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectItems : MonoBehaviour
{
    int collected = 0;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            collected = 0;
            //transform.position = startPosition;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            collected = 0;
        }

        if (collision.gameObject.CompareTag("Collectable")) {
            Destroy(collision.gameObject);

            collected += 1;
        }

        if (collected >= 3)
        {
            Destroy(gameObject);
        }
    }
}
