using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private float sensitivity = 10f;

    [SerializeField]
    private Transform player;

    private float newX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");

        player.eulerAngles += Vector3.up * y * sensitivity;
        transform.eulerAngles += Vector3.up * y * sensitivity;

        newX += x * sensitivity * -1f;

        newX = Mathf.Clamp(newX, -25f, 50f);
        transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, transform.eulerAngles.z);

        transform.position = player.position + new Vector3(0, 1, 0); 
    }
}
