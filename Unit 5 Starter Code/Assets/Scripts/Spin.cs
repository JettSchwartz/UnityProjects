using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private Rigidbody targetRB;

    private void Awake()
    {
        targetRB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetRB.AddForce(Force(), ForceMode.Impulse);
        targetRB.AddTorque(Torque(), Torque(), Torque(), ForceMode.Impulse);
    }

    private Vector3 Force()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(-2f, 5);
        Vector3 direction = new Vector3(x, y, -1f);
        return direction;
    }

    private float Torque()
    {
        float spin = Random.Range(-10, 10);
        return spin;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7f || transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
