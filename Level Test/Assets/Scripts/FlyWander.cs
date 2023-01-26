using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWander : MonoBehaviour
{
    private Rigidbody myRB;
    private Vector3 dir;
    private float flyForce;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDir());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // apply force to move 
        myRB.AddForce(dir * flyForce, ForceMode.Force);

        // Point forward
        transform.forward = myRB.velocity;

    }

    private IEnumerator ChangeDir()
    {
        float newX;
        float newZ;

        float waitTime;

        while (true)
        {
            // get a new direction
            newX = Random.Range(-1.0f, 1.0f);
            newZ = Random.Range(-1.0f, 1.0f);
            dir = new Vector3(newX, 0, newZ);

            // get new speed
            flyForce = Random.Range(1.0f, 3.0f);

            // wait random number of time before changing direction again
            waitTime = Random.Range(1.0f, 4.0f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
