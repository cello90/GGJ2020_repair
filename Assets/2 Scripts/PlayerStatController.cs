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
    public float charge = 100;

    // Update is called once per frame
    void Update()
    {
        if (pluggedIn)
        {
            if (charge < 100)
                charge += chargeRate * Time.deltaTime;
            if (charge > 100)
                charge = 100;
        }
        else
        {
            charge -= dischargeRate * Time.deltaTime;
            if (charge < 0)
            {
                Application.LoadLevel(1);
            }
        }
    }
}
