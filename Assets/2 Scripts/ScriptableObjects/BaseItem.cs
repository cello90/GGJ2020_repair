using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class BaseItem : MonoBehaviour
{

    public SO_BaseItem item;

    // Start is called before the first frame update
    void Start()
    {
        if(!this.gameObject.GetComponent<SpriteRenderer>())
        {
            this.gameObject.AddComponent<SpriteRenderer>();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = item.SO_Sprite;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
