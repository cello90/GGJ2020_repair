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
    public bool isFixed = false;
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

        checkIfFixed();
    }

    // Update is called once per frame
    void Update()
    {
        // Auto set sprite
        if (_sprite == null) 
        { 
            if(feature.SO_Sprite != null)
            {
                _sprite = feature.SO_Sprite;
                if (isFixed)
                    _sprite = feature.SO_Fixed_Image;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
            }
            checkIfFixed();
        }
    }


    void checkIfFixed()
    {
        if (isFixed)
        {
            _sprite = feature.SO_Fixed_Image;
            Debug.Log("Updating sprite to a fixed sprite. isFixed: " +isFixed);
        }
    }
}
