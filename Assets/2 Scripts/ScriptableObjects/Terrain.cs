using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Terrain : MonoBehaviour
{

    public SO_Terrain terrain;

    private Sprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        if (!this.gameObject.GetComponent<SpriteRenderer>())
        {
            this.gameObject.AddComponent<SpriteRenderer>();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = terrain.SO_Sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_sprite == null) 
        { 
            if(terrain.SO_Sprite != null)
            {
                _sprite = terrain.SO_Sprite;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(terrain.terrain == Enum_Terrains.Elevator)
        {
            // TEMP CODE -> Need to have this system more blown out
            GameObject.Find("Menu_Elevator").transform.Find("Image").transform.position = new Vector3(0, 0, 0);
        }

        else if(collision.gameObject.GetComponent<Zac_Test_move>().item == terrain.problem_solver)
        {
            // 
            collision.gameObject.GetComponent<Zac_Test_move>().item = null;
            Destroy(this.gameObject);
        }
    }
}
