using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;
    
    void Start()
    {
        offset = new Vector3(0, 2, 5);
    }

    private void FixedUpdate()
    {
        transform.position = playerTransform.position + offset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 90);
            offset = Quaternion.AngleAxis(90, Vector3.up) * offset;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -90);
            offset = Quaternion.AngleAxis(-90, Vector3.up) * offset;
        }
    }
}
