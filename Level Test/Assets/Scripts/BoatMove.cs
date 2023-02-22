using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = (Mathf.Sin(Time.time) + 1f) * 9f;

        transform.position = startPosition + new Vector3(offsetX, 0, 0);
    }
}
