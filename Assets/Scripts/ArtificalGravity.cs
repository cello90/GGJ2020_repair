﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificalGravity : MonoBehaviour
{

    public float gravityMult = 1;
    private float g = -9.81f;
    private Transform _gc;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        _rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per Physics loop
    void FixedUpdate()
    {
        
    }

    void updateGravity()
    {
        _rb.AddForce
    }
}
