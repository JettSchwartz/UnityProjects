using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackJump : Attack
{
    [SerializeField]
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void DoAttack(GameObject target)
    {
        base.DoAttack(target);

        // get the jump direction
        Vector3 dir = attackTarget.transform.position - transform.position;

        dir = dir.normalized;

        // add in the force
        dir.y = 0.4f;
        dir *= jumpForce;

        // apply to force
        myRB.AddForce(dir, ForceMode.Impulse);

        // face forward
        transform.forward = dir;
    }
}
