using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundHandler : MonoBehaviour
{

    private GameObject player;
    private float distance;
    private Transform _gc; //Gravity Center

    // Start is called before the first frame update
    void Start()
    {
        _gc = GameObject.FindGameObjectWithTag("Gravity Center").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        distance = player.GetComponent<ArtificalGravity>().shipRadius;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = player.transform.eulerAngles;
        transform.position = _gc.position - (transform.up * (distance + 0.5f));
    }
}
