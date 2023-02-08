using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAttack : MonoBehaviour
{
    private Rigidbody myRB;
    private Animator myAnim;
    private string runAnim = "Run";
    private GameObject attackTarget;

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
}
