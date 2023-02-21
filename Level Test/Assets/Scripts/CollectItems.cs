using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    int collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            print("yes");
            Destroy(gameObject);
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
