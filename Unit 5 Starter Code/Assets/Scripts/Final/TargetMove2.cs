using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove2 : MonoBehaviour
{
    private Rigidbody targetRB;

    private GameManager2 gmScript;

    [SerializeField]
    private ParticleSystem splash;

    [SerializeField]
    private int points;

    private void Awake()
    {
        targetRB = GetComponent<Rigidbody>();
        gmScript = GameObject.Find("SpawnManager").GetComponent<GameManager2>();
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
        if (transform.position.x > 7f || transform.position.y < -1f)
        {
            Destroy(gameObject);
            // When the item is not an onion, the player is penalized and loses a life
            if (!gameObject.CompareTag("Ghost"))
            {
                gmScript.UpdateScore(-5);
                gmScript.UpdateLives();
                gmScript.PlaySound("Miss");
            }
        }
    }

    // Checks to see which prefab has been chopped
    private void OnMouseDown()
    {
        for (int i = 0; i < gmScript.targetPrefab.Length; i++)
        {
            if (gameObject.CompareTag(gmScript.targetPrefab[i].tag))
            {
                Instantiate(splash, gameObject.transform.position, gameObject.transform.rotation);

                
                gmScript.UpdateScore(points);
                // Pass the fruit that has been clicked on
                gmScript.PlaySound(gmScript.targetPrefab[i].tag);
                Destroy(gameObject);
            }
        }
    }
}
