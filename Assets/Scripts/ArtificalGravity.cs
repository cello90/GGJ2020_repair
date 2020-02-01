using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificalGravity : MonoBehaviour
{

    private Transform _gc;

    // Start is called before the first frame update
    void Start()
    {
        _gc = GameObject.FindGameObjectWithTag('test');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
