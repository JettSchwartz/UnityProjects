using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    private Rigidbody targetRB;

    private GameManager gmScript;

    private void Awake()
    {
        targetRB = GetComponent<Rigidbody>();
        gmScript = GameObject.Find("SpawnManager").GetComponent<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(1f, 1.75f) * 3;
        float y = Random.Range(1f, 1.6f) * 6;
        Vector3 dir = new Vector3(x, y, 0);
        targetRB.AddForce(dir, ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    private Vector3 RandomTorque()
    {
        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);
        Vector3 spin = new Vector3(x, y, z);
        return spin;
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7f || transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < gmScript.targetPrefabs.length; i++)
        {

        }



        Destroy(gameObject);
    }
}
