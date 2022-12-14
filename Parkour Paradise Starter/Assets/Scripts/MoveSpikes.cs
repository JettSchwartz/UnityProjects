using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikes : MonoBehaviour
{
    private BallMove ballScript;


    private float moveDistance = 0.1f;
    private float speed = 2f;

    private void Start()
    {
        GameObject ball = GameObject.Find("ball");
        ballScript = ball.GetComponent<BallMove>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (ballScript.leverOn == false)
        {
            return;
        }

        float distance = (Mathf.Sin(Time.time * speed)) * moveDistance * 60 / 2;
        print(distance);
        transform.Translate(Vector3.down * distance * Time.deltaTime, Space.Self);

    }
}
