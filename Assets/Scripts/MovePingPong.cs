using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePingPong : MonoBehaviour
{
    private Vector3 startPos;
    private int randomSpeed;
    void Start()
    {
        startPos = gameObject.transform.position;
        randomSpeed = Random.Range(1, 5);
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time/randomSpeed,1.5f), startPos.y, startPos.z);
    }
}
