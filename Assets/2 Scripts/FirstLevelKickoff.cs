using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelKickoff : MonoBehaviour
{

    public AudioClip start_Music = null;

    // Start is called before the first frame update
    void Start()
    {
        if (!Game.instance.firstMesssageRecieved)
        {
            Game.instance.PauseGame(true);

            Game.instance.CompletedATask(this.gameObject, Game.instance.json.GetMessage(0), null);

            Game.instance.firstMesssageRecieved = true;
        }
    }
}
