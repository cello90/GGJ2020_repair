using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //The object the camera will follow
    public Transform target;

    public float changeRate = 0.1f;
    public float rotationRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandlePosition();
        HandleRotation();
    }

    void HandlePosition()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - Vector3.forward, changeRate);
    }

    void HandleRotation()
    {
        Vector3 Pos = new Vector3(0, 0, target.eulerAngles.z);
        Vector3 Neg = new Vector3(0, 0, target.eulerAngles.z - 360);
        if (Vector3.Distance(transform.eulerAngles, Pos) < Vector3.Distance(transform.eulerAngles, Neg))
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Pos, rotationRate);
        }
        else
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Neg, rotationRate);
        }
        transform.eulerAngles = target.eulerAngles;
    }
}
