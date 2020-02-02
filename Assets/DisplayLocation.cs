using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLocation : MonoBehaviour
{

    private Text _to;

    // Start is called before the first frame update
    void Start()
    {
        _to = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _to.text = Application.loadedLevelName;
    }
}
