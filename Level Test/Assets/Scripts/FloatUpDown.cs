using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    float height = 1;
    float speed = 1;

    float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float heightOffset = Mathf.Sin(Time.time * speed) + 1;
        heightOffset *= 0.5f * height;

        transform.position = new Vector3(transform.position.x, startY + heightOffset, transform.position.z);
        transform.Rotate(new Vector3(0, Time.deltaTime * speed * 10, 0));
    }
}
