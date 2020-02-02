using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public int startLevel = 3;

    public void resume()
    {
        //todo
    }

    public void NewGame()
    {
        Game.instance.Reset();
        Application.LoadLevel(startLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
