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
    }

    void HandleRadius()
    {
        if (Vector3.Distance(transform.position, _gc.position) + _cc.radius >= shipRadius)
        {
            FixVel();
        }
        else
        {
            UpdateGravity();
        }

    }
    void FixVel()
    {
        float startAngle = 0;
        if (_rb.velocity.x < 0) {
            startAngle = Mathf.Tan(_rb.velocity.y / _rb.velocity.x) + 90;
        }
        else
        {
            startAngle = Mathf.Tan(_rb.velocity.y / _rb.velocity.x) - 90;
        }
        float playerAngle = transform.eulerAngles.z; 
        float newAngle = startAngle - playerAngle;
        float magnitude = _rb.velocity.magnitude;
        float xVel = Mathf.Cos((newAngle * Mathf.PI) / 180) * magnitude;
        float yVel = Mathf.Sin(Mathf.PI - ((newAngle * Mathf.PI) / 180)) * magnitude;
        Debug.Log(yVel);
        //_rb.velocity = transform.right * xVel;
        if (yVel > 0)
            _rb.velocity = (transform.right * xVel) + (transform.up * yVel);
        else
            _rb.velocity = transform.right * xVel;
    }

    void FixPos()
    {

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
