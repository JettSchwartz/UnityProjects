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
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        myRB.AddForce(dir * flyForce, ForceMode.Force);

    }
}
