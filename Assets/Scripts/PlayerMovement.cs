using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 10;
    public float groundRange = 0.6f;

    //private object references
    private Rigidbody2D _rb; //our RigidBody

    private bool _grounded = false;

    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get the required components
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        HandleInput();
        Debug.DrawLine(transform.position, transform.position + transform.right, Color.red);
        Debug.DrawLine(transform.position, transform.position - transform.right, Color.red);
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
        if (Input.GetAxis("Jump") > 0 && _grounded)
        {
            Jump();
        }
        Move();
    }

    void Jump()
    {
        _rb.AddForce(transform.up * jumpForce);
    }

    void Move()
    {
        _rb.AddForce(transform.right * Input.GetAxis("Horizontal") * speed);
    }
}
