using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private float sensitivity = 10;

    [SerializeField]
    private Transform player;

    private float newX;

    private GameManager gmScript;

    private void Awake()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Hides our mouse
        
    }

    // Called at the end of each frame - prevent jittery camera movement
    void LateUpdate()
    {
        if (gmScript.isGameActive == true)
        {
            // Get the mouse X and Y positions
            float y = Input.GetAxis("Mouse X");
            float x = Input.GetAxis("Mouse Y");

            // Rotate the player left and right
            player.eulerAngles += Vector3.up * y * sensitivity;
            transform.eulerAngles += Vector3.up * y * sensitivity;

            // Rotate the camera up and down
            newX += x * sensitivity * -1f;
            newX = Mathf.Clamp(newX, -25f, 50f);
            transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, transform.eulerAngles.z);

            // Make focal point follow player around
            transform.position = player.position;
        }
    }
}
