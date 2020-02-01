using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificalGravity : MonoBehaviour
{

    private Transform _gc;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        _rb = GetComponent<GameObject>
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
