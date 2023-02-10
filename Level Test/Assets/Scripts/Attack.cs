using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    protected Rigidbody myRB;
    protected Animator myAnim;
    protected GameObject attackTarget = null;

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
            DoAttack(other.gameObject);
        }
    }

    protected virtual void DoAttack(GameObject target)
    {
        attackTarget = target;
    }
}
