using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public int currentRoom;

    public static Game instance = null;

    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed another instance of Game");
        }
        
    }

    public void LoadScene(int roomNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room" + roomNumber);
    }


}
