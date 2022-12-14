using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikes : MonoBehaviour
{
    public GameObject spike1;
    public GameObject spike2;
    // Start is called before the first frame update
    public void MoveSpike()
    {
        spike1.transform.position = new Vector3(132, 168.37f, 19.58f);
        spike2.transform.position = new Vector3(150, 168.37f, 19.58f);
        Debug.Log("a");
    }
}
