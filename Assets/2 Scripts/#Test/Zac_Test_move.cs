using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zac_Test_move : MonoBehaviour
{

    private void OnEnable()
    {
        Game.EnterCollider += TestScript;
    }

    private void OnDisable()
    {
        Game.EnterCollider -= TestScript;
    }


    void TestScript(object obj, InfoEventArgs<GameObject, string> e)
    {



        Debug.Log("Test : " + e.Subtype);
    }

}
