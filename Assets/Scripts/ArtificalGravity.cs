using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArtificalGravity : MonoBehaviour
{
    //level design varibles
    public float gravityMult = 1;

    //[Header("Only turn this setting off if this is on the player")]
    private bool applyGravity = true;

    [Header("DO NOT TOUCH")]
    public Vector3 gVector;

    [Header("Player Settings")]
    public bool isPlayer = false;
    public float shipRadius = 5;
    public GameObject ground;

    //private object references
    private Transform _gc; //Gravity Center
    private Rigidbody2D _rb; //our RigidBody
    private CircleCollider2D _cc;

    //constants
    private float g = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        //Get the required components
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        _rb = GetComponent<Rigidbody2D>();
        _cc = GetComponent<CircleCollider2D>();

        _rb.gravityScale = 0; //Prevent mistakes by removing unity default gravity

        _rb.velocity = transform.up;

        g = Physics.gravity.y; //Ensure that we have the correct value of little g
    }

    // FixedUpdate is called once per Physics loop
    void FixedUpdate()
    {
        HandleRadius();
        Debug.DrawLine(transform.position, (Vector2)transform.position + _rb.velocity, Color.blue);
    }

    void HandleRadius()
    {
        UpdateGravity();
    }

    void UpdateGravity()
    { 
        gVector = (_gc.position - transform.position).normalized * g * GravityMult() * Time.fixedDeltaTime;
        if (applyGravity)
            _rb.AddForce(gVector);

    }

    float GravityMult()
    {
        return Vector3.Distance(transform.position, _gc.position) * gravityMult;
    }
}
