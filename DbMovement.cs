using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbMovement : MonoBehaviour
{
    public Vector3 centerPoint; 
    public float radius = 0.3f;
    public float rotationSpeed = 1.5f;
    public float angle = 0f;
    private bool increasing = true; 

    void Start()
    {
        centerPoint = transform.position + Vector3.left * radius;
        centerPoint.y -= radius;
    }

    void Update()
    {
        // DbCurls();
        DbLatRaise();
    }

    void DbCurls(){
        if (increasing)
        {
            angle += rotationSpeed * Time.deltaTime;
            if (angle > Mathf.PI / 2) 
            {
                increasing = false;
                angle = Mathf.PI / 2;
            }
        }
        else
        {
            angle -= rotationSpeed * Time.deltaTime;
            if (angle < 0)
            {
                increasing = true;
                angle = 0;
            }
        }
   
        float y = Mathf.Sin(angle) * radius + centerPoint.y + radius; 
        float z = Mathf.Cos(angle) * radius + centerPoint.z; 
      
        transform.position = new Vector3(centerPoint.x, y, z);
    }

void DbLatRaise()
{
    if (angle == 0 && increasing)
    {
        if (gameObject.tag == "DbR")
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 78, -12);
        }
        else if (gameObject.tag == "DbL")
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -78, 12);
        }
    }

    if (gameObject.tag == "DbR")
    {
        if (increasing)
        {
            angle += rotationSpeed * Time.deltaTime;
            if (angle > Mathf.PI / 2)
            {
                increasing = false;
                angle = Mathf.PI / 2;
            }
        }
        else
        {
            angle -= rotationSpeed * Time.deltaTime;
            if (angle < 0)
            {
                increasing = true;
                angle = 0;
            }
        }
    }
    else if (gameObject.tag == "DbL")
    {
        if (increasing)
        {
            angle -= rotationSpeed * Time.deltaTime;
            if (angle < -Mathf.PI / 2) 
            {
                increasing = false;
                angle = -Mathf.PI / 2;
            }
        }
        else
        {
            angle += rotationSpeed * Time.deltaTime;
            if (angle > 0)
            {
                increasing = true;
                angle = 0;
            }
        }
    }

    float y = Mathf.Sin(Mathf.Abs(angle)) * radius + centerPoint.y + radius;
    float x = (gameObject.tag == "DbR" ? 1 : -1) * Mathf.Cos(Mathf.Abs(angle)) * radius + centerPoint.x;

    transform.position = new Vector3(x, y, centerPoint.z);
    }
}
