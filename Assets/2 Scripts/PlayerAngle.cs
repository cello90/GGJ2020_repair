using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngle : MonoBehaviour
{

    public bool inGravity = true;

    //private object references
    private Transform _gc; //Gravity Center
    private Rigidbody2D _rb; //our RigidBody

    // Start is called before the first frame update
    void Start()
    {
        //Get the required components
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        _rb = GetComponent<Rigidbody2D>();
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (inGravity)
        {
            if ((_gc.position.x - transform.position.x) != 0)
            {
                if (transform.position.x < _gc.position.x)
                    transform.eulerAngles = new Vector3(0, 0, ((Mathf.Atan((_gc.position.y - transform.position.y) / (_gc.position.x - transform.position.x)) * 180) / Mathf.PI) - 90);
                else
                    transform.eulerAngles = new Vector3(0, 0, ((Mathf.Atan((_gc.position.y - transform.position.y) / (_gc.position.x - transform.position.x)) * 180) / Mathf.PI) + 90);
            }
            else
            {
                if ((_gc.position.y - transform.position.y) > 0)
                    transform.eulerAngles = new Vector3(0, 0, 0);
                else
                    transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
        else
        {
            transform.eulerAngles += new Vector3(0,0,Input.GetAxis("Mouse X"));
        }
    }
}
