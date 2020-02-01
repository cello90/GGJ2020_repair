using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //The object the camera will follow
    public Transform target;

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
        transform.position = target.position - Vector3.forward;
    }

    void HandleRotation()
    {
        transform.eulerAngles = target.eulerAngles;
    }
}
