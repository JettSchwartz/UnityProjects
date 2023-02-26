using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderFly : Attack
{

    [SerializeField]
    private float jumpForce;

    private bool isAttack = false;

    [SerializeField]
    private float minX, maxX, minZ, maxZ, minForce, maxForce;

    private Vector3 dir;
    private float flyForce;

    // Start is called before the first frame update
    void Start()
    {
        if (isAttack == false)
        {
            StartCoroutine(ChangeDir());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == false)
        {
            Move();
        }
    }

    private void Move()
    {
        float newX;
        float newZ;

        // apply force to move 
        myRB.AddForce(dir * flyForce, ForceMode.Force);

        // Point forward
        transform.forward = myRB.velocity;

        // keep in bounds
        newX = Mathf.Clamp(transform.position.x, minX, maxX);
        newZ = Mathf.Clamp(transform.position.z, minZ, maxZ);

        // turn around at edge of mountain
        if (newX != transform.position.x || newZ != transform.position.z)
        {
            myRB.AddForce(myRB.velocity * -10, ForceMode.Force);
        }

        // apply boundary
        transform.position = new Vector3(newX, transform.position.y, newZ);
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
            flyForce = Random.Range(minForce, maxForce);

            // wait random number of time before changing direction again
            waitTime = Random.Range(1.0f, 4.0f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    protected override void DoAttack(GameObject target)
    {
        base.DoAttack(target);
        isAttack = true;

        // get the jump direction
        Vector3 dir = attackTarget.transform.position - transform.position;

        dir = dir.normalized;

        // add in the force
        dir *= jumpForce;

        // apply to force
        myRB.AddForce(dir, ForceMode.Impulse);

        // face forward
        transform.forward = dir;
    }
}
