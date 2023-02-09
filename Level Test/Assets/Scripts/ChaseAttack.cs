using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAttack : MonoBehaviour
{
    [SerializeField]
    private float chaseSpeed;

    private Rigidbody myRB;
    private Animator myAnim;
    private string runAnim = "Run";
    private GameObject attackTarget = null;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack(other.gameObject);
        }
    }

    private void Attack(GameObject target)
    {
        attackTarget = target;
        myAnim.SetBool(runAnim, true);
    }

    private void Chase()
    {
        if (attackTarget != null)
        {
            // get dirrection towards my target
            Vector3 dir = attackTarget.transform.position - transform.position;
            dir = dir.normalized;

            dir *= chaseSpeed;

            myRB.AddForce(dir, ForceMode.Force);

            //face forward
            transform.forward = myRB.velocity;
        }
    }
}
