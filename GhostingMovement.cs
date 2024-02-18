using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostingMovement : MonoBehaviour
{
    public Vector3 centerPoint;
    public float radius = .5f; 
    public float rotationSpeed = 2f;
    public float angle = 0f;


    private void Start()
    {
        centerPoint = transform.position + transform.up * radius;
    }

    private void Update()
    {
        angle += rotationSpeed * Time.deltaTime;

        float y = Mathf.Cos(angle) * radius + centerPoint.y;
        float z = Mathf.Sin(angle) * radius + centerPoint.z;

        transform.position = new Vector3(centerPoint.x, y, z);

        // Optional: make obj face the direction it is moving
        // float nextY = Mathf.Cos(angle + 0.1f) * radius + centerPoint.y;
        // float nextZ = Mathf.Sin(angle + 0.1f) * radius + centerPoint.z;
        // transform.LookAt(new Vector3(centerPoint.x, nextY, nextZ));
    }
}

