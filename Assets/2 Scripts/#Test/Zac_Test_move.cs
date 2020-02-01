using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zac_Test_move : MonoBehaviour
{

    public float speed = 5.0f;

    private Collider2D hittingACollider;

    public SO_BaseItem item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector2(pos.x - speed, pos.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector2(pos.x + speed, pos.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector2(pos.x, pos.y + speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector2(pos.x, pos.y - speed);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hittingACollider = collision;

        if (hittingACollider.gameObject.GetComponent<BaseItem>() && item == null)
        {
            item = hittingACollider.gameObject.GetComponent<BaseItem>().item;
            Debug.Log("Player destroying item...");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hittingACollider = null;
    }

}
