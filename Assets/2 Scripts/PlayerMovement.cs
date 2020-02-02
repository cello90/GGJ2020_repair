using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 10;
    public float groundRange = 0.6f;
    public float falseFriction = 1.5f;
    public Animator _anim;

    //private object references
    private bool paused = false;

    private Rigidbody2D _rb; //our RigidBody

    private bool _grounded = false;

    private bool jumping = false;
    private AudioSource feet;

    void OnEnable()
    {
        Game.IsPausedEvent += Pause;
    }

    private void OnDisable()
    {
        Game.IsPausedEvent -= Pause;
    }

    private void Pause(object obj, InfoEventArgs<bool> e)
    {
        if (e.info == true)
            paused = true;
        else
            paused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get the required components
        _rb = GetComponent<Rigidbody2D>();
        feet = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            CheckGround();
            HandleInput();
            Debug.DrawLine(transform.position, transform.position + transform.right, Color.red);
            Debug.DrawLine(transform.position, transform.position - transform.right, Color.red);
        }
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
        if (_grounded)
        {
            _rb.velocity = _rb.velocity / falseFriction;
        }
    }

    void Jump()
    {
        _rb.AddForce(transform.up * jumpForce);
    }

    void Move()
    {
        _rb.AddForce(transform.right * Input.GetAxis("Horizontal") * speed);
        if (Input.GetAxis("Horizontal") != 0 && !feet.isPlaying)
        {
            feet.Play();
        }
        if (Input.GetAxis("Horizontal") > 0)
            _anim.SetInteger("Run", 1);
        else if (Input.GetAxis("Horizontal") < 0)
            _anim.SetInteger("Run", -1);
        else
        {
            _anim.SetInteger("Run", 0);
            feet.Stop();
        }
    }
}
