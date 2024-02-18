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
        // Calculate the new angle based on rotation speed and time
        angle += rotationSpeed * Time.deltaTime;

        // Convert angle to radians and calculate x and z positions
        float y = Mathf.Cos(angle) * radius + centerPoint.y;
        float z = Mathf.Sin(angle) * radius + centerPoint.z;

        // Update the position of the object
        transform.position = new Vector3(centerPoint.x, y, z);

        // // Optional: Make the object face the direction it is moving by looking at the next point along the circle
        // float nextY = Mathf.Cos(angle + 0.1f) * radius + centerPoint.y;
        // float nextZ = Mathf.Sin(angle + 0.1f) * radius + centerPoint.z;
        // transform.LookAt(new Vector3(centerPoint.x, nextY, nextZ));
    }
}

//shoulder w/o: 10 small fwd&bw, 10 med fwd&bw, 10 wide fwd&bw
//breathing w/o: sphere or other object, scales to outside then back to inside by seconds
//v2: attached yogi studio
//v?: supplements give power
//v?: treadmill: future walking screen