using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public int currentRoom;
    public bool inMenu = false;
    public static Game instance = null;
    public GameObject player = null;
    public SO_RoomFeature door = null;
    public MusicManager music = null;
    public List<BaseItem> completedTasks = new List<BaseItem>();
    public SO_BaseItem currentItem = null;

    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            music = this.gameObject.AddComponent<MusicManager>();

        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed another instance of Game");
        }
        
    }

    public void LoadScene(int roomNumber)
    {
        player = null;
        currentRoom = roomNumber;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room" + roomNumber);
    }

    private void Update()
    {
        if(player == null && !inMenu)
        {
            player = GameObject.Find("Player");
            if(player == null || player == false)
            {
                spawnPlayer();
            }
        }
    }

    private void spawnPlayer()
    {
        GameObject gravityCenter = Instantiate(new GameObject());
        gravityCenter.name = "Gravity Center";
        gravityCenter.tag = "Gravity Center";

        player = Instantiate(Resources.Load<GameObject>("Player"));
        player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        player.gameObject.name = "Player";



        if (currentRoom == 0)
        {
            player.transform.Find("PlayerPhysics").gameObject.transform.position = new Vector3(
                GameObject.Find("SpawnLocation").transform.position.x,
                GameObject.Find("SpawnLocation").transform.position.y,
                -3f
                );
            
        }
        else if (door == null)
        {
            Debug.LogError("Should have a door");
        }
        else
        {
            //player.transform.Find("PlayerPhysics").gameObject.transform.position

            RoomFeature[] objects = GameObject.FindObjectsOfType<RoomFeature>();

            Debug.Log("Count of room features: " + objects.Length);

            foreach (RoomFeature obj in objects)
            {
                Debug.Log("Current feature: " + obj.feature + " searching: " + door.SO_Door_LinkedTo);
                if (obj.feature == door.SO_Door_LinkedTo)
                {
                    player.transform.Find("PlayerPhysics").gameObject.transform.position = new Vector3(
                        obj.transform.position.x,
                        obj.transform.position.y,
                        -3f
                        );
                    player.transform.Find("PlayerPhysics").gameObject.transform.eulerAngles = obj.transform.eulerAngles;
                }
                else if(obj.feature == door)
                {
                    player.transform.Find("PlayerPhysics").gameObject.transform.position = new Vector3(
                        obj.transform.position.x,
                        obj.transform.position.y,
                        -3f
                        );
                    player.transform.Find("PlayerPhysics").gameObject.transform.eulerAngles = obj.transform.eulerAngles;
                }
            }

            door = null;
        }

        player.transform.Find("Main Camera").gameObject.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            -10f
            );
    }
}


