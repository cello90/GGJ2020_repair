﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public int waitTimer = 5;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = waitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Application.LoadLevel(0);
            //Game.instance.re
        }
    }
}
