using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadedNotification : MonoBehaviour
{
    private void OnEnable()
    {
        //Game.instance.UpdateScene();
    }

    private void Start()
    {
        Game.instance.UpdateScene();
    }

    private void CheckRoomForUnlockedThings()
    {

    }
}
