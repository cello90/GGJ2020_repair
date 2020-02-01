using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class powerDisplay : MonoBehaviour
{

    public PlayerStatController player;
    private int section = 0;
    public Texture[] powerLevel;
    private float change;
    private RawImage powerIndicator;

    // Start is called before the first frame update
    void Start()
    {
        powerIndicator = GetComponent<RawImage>();
        change = 100 / (powerLevel.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.charge <= 0)
        {
            powerIndicator.texture = powerLevel[powerLevel.Length - 1];
        }
        else
        {
            float val = player.charge / change;
            val = (int) ((powerLevel.Length - 1) - val);
            powerIndicator.texture = powerLevel[(int) val];
        }
    }
}
