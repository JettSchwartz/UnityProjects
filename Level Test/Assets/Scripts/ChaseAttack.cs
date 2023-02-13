using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAttack : Attack
{
    [SerializeField]
    private float chaseSpeed;

    private string runAnim = "Run";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    protected override void DoAttack(GameObject target)
    {
        base.DoAttack(target);

        myAnim.SetBool(runAnim, true);
    }

    private void Chase()
    {
        if (attackTarget != null)
        {
            // get dirrection towards my target
            Vector3 dir = attackTarget.transform.position - transform.position;
            dir = dir.normalized;

            dir.y = 0.2f;
            dir *= chaseSpeed;

            myRB.AddForce(dir, ForceMode.Force);

            //face forward
            transform.forward = new Vector3(myRB.velocity.x, transform.forward.y, myRB.velocity.z);
        }
    }
}
