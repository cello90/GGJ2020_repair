using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArtificalGravity : MonoBehaviour
{

    public float gravityMult = 1;
    private float g = -9.81f;
    private Transform _gc;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        _rb = GetComponent<Rigidbody2D>();
        g = Physics.gravity.y;
    }

    // FixedUpdate is called once per Physics loop
    void FixedUpdate()
    {
        UpdateGravity();
    }

    void UpdateGravity()
    {
        _rb.AddForce((_gc.position - transform.position).normalized * g * GravityMult());
    }

    float GravityMult()
    {
        return Vector3.Distance(transform.position, _gc.position);
    }
}
