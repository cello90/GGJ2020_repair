using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //The object the camera will follow
    public Transform target;
    public float speed = 3f;

    public float changeRate = 0.1f;
    public float rotationRate = 0.5f;
    public Vector3 cameraRelOffset = new Vector3(0,0,-10);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = (target.position - 10 * transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        HandlePosition();
        HandleRotation();
    }

    void HandlePosition()
    {

        Vector3 targetLoc = target.position + (transform.right * cameraRelOffset.x) + (transform.up * cameraRelOffset.y) + (transform.forward * cameraRelOffset.z);

        if (Vector3.Distance(transform.position, targetLoc) >= Time.deltaTime * speed)
            transform.position += (targetLoc - transform.position).normalized * Time.deltaTime * speed;
        else
            transform.position = targetLoc;
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
