using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    private float speed = 100;
    private Vector3 originalPosition;
    private float originalZ;
    private BallMove BallMoveScript;

    private GameManager gmScript;

    private void Awake()
    {
        BallMoveScript = GameObject.Find("ball").GetComponent<BallMove>();
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalZ = originalPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gmScript.UpdateCoins();
            Destroy(gameObject);
        }

    }
}
