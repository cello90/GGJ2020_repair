using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemDisplay : MonoBehaviour
{

    private RawImage _ri;

    // Start is called before the first frame update
    void Start()
    {
        _ri = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.instance.currentItem == null)
        {
            _ri.color = new Color(0,0,0,0);
        }
        else
        {
            _ri.color = new Color(255, 255, 255, 255);
            _ri.texture = Game.instance.currentItem.SO_Sprite.texture;
        }
    }
}
