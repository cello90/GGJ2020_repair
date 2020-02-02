using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{

    //public varibles
    public float dischargeRate = 1;
    public float chargeRate = 1;

    [Header("DO NOT TOUCH")]
    public bool pluggedIn = false;

    // Update is called once per frame
    void Update()
    {
        if (pluggedIn)
        {
            if (Game.instance.power < 100)
                Game.instance.power += Game.instance.power * Time.deltaTime;
            if (Game.instance.power > 100)
                Game.instance.power = 100;
        }
        else
        {
            Game.instance.power -= dischargeRate * Time.deltaTime;
            if (Game.instance.power < 0)
            {
                Game.instance.power = 100f;
                Application.LoadLevel(1);
            }
        }
    }
}
