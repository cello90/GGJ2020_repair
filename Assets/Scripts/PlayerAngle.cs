﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngle : MonoBehaviour
{

    //private object references
    private Transform _gc; //Gravity Center
    private Rigidbody2D _rb; //our RigidBody


    //z

    // Start is called before the first frame update
    void Start()
    {
        //Get the required components
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, ((Mathf.Atan((_gc.position.y - transform.position.y)/ (_gc.position.x - transform.position.x)) * 180) / Mathf.PI) - 90);
    }
}
