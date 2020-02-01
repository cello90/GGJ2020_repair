using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

[ExecuteInEditMode]
public class BaseItem : MonoBehaviour
{

    public SO_BaseItem item;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();     
    }

    public void UpdateSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = item.SO_Sprite;

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((S.x/2), 0);
    }
}
