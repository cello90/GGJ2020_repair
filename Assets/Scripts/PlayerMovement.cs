using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ArtificalGravity))]
public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 10;
    public float groundRange = 0.6f;

    //private object references
    private Rigidbody2D _rb; //our RigidBody
    private ArtificalGravity _ag; //our Artificial Gravity Handler

    private bool _grounded = false;
    private float upVel = 0;

    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get the required components
        _rb = GetComponent<Rigidbody2D>();
        _ag = GetComponent<ArtificalGravity>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        HandleInput();
    }

    void CheckGround()
    {
        RaycastHit hit;
        if (Physics2D.Raycast(transform.position, -transform.up, groundRange))
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
    }

    void HandleInput()
    {
        Debug.Log(Input.GetAxis("Jump"));
        if (Input.GetAxis("Jump") > 0 && _grounded)
        {
            Jump();
        }
        Move();
    }

    void Jump()
    {
        upVel += jumpForce;
        jumping = true;
    }

    void Move()
    {
        _rb.velocity = transform.right * Input.GetAxis("Horizontal") + (transform.up * upVel);
        if (!_grounded)
        {
            upVel -= _ag.gVector.magnitude * Time.deltaTime;
            jumping = false;
        }
        else if(!jumping)
        {
            upVel = 0;
        }
    }
}
