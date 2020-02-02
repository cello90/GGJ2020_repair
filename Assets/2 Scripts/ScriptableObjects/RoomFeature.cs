using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

[ExecuteInEditMode]
public class RoomFeature : MonoBehaviour
{

    public SO_RoomFeature feature;

    private Sprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        if (feature.SO_Sprite == null || feature.SO_Sprite == false)
            Debug.LogError(this.name + " is missing a sprite!");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = feature.SO_Sprite;

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        Vector2 S = new Vector2(
            gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x * gameObject.transform.localScale.x,
            gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * gameObject.transform.localScale.y
            );
        gameObject.GetComponent<BoxCollider2D>().size = S;
        //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((S.x / 2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_sprite == null) 
        { 
            if(feature.SO_Sprite != null)
            {
                _sprite = feature.SO_Sprite;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(feature.feature_enum == Enum_Feature.Elevator)
        {
            // TEMP CODE -> Need to have this system more blown out
            GameObject.Find("Menu_Elevator").transform.Find("Image").transform.position = new Vector3(0, 0, 0);
        }

        else if(feature.feature_enum == Enum_Feature.Door)
        {
            
        }

        //else if(collision.gameObject.GetComponent<Zac_Test_move>().item == feature.problem_solver)
        //{
        //    // 
        //    collision.gameObject.GetComponent<Zac_Test_move>().item = null;
        //    Debug.Log("Terrain destroying self...");
        //    Destroy(this.gameObject);
        //}
    }

    private void SolvedProblem()
    {

    }

    
}
