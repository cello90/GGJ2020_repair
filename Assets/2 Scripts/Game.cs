using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Game State
    public int currentRoom;
    public bool inMenu = false;
    public TextAsset json_file = null;
    public TextAsset hints = null;

    // Singleton code
    public static Game instance = null;
   
    // Managers
    public MusicManager music = null;
    public JSON_Manager json = null;

    // Achievements
    public List<SO_BaseItem> completedTasks = new List<SO_BaseItem>();
    
    // Current player stuff
    public SO_BaseItem currentItem = null;
    public float power = 100;
    public GameObject player = null;
    public SO_RoomFeature door = null;
    public float rewardChargeAmount = 10f;

    // Notification Constants
    public static event EventHandler<InfoEventArgs<GameObject, string>> EnterCollider;
    public static event EventHandler<InfoEventArgs<GameObject>> ExitCollider;
    public static event EventHandler<InfoEventArgs<bool>> IsPausedEvent;
    public static event EventHandler<InfoEventArgs<AudioClip, string>> CompleteTask;

    public bool firstMesssageRecieved = false;

    public int winScene = 9;

    public bool swapScene = false;

    public Animator sceneSwap;

    private int newRoomNumber = 0;


    private void OnEnable()
    {
        if(instance == null)
        {

            if(json_file == null)
            {
                json_file = Resources.Load<TextAsset>("GGJ.json");
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
            music = this.gameObject.AddComponent<MusicManager>();
            json = this.gameObject.AddComponent<JSON_Manager>();
            sceneSwap = this.gameObject.GetComponent<Animator>();
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed another instance of Game");
        }
        
    }

    public void LoadScene(int roomNumber)
    {
        newRoomNumber = roomNumber;
        sceneSwap.SetTrigger("Swap");
    }

    private void Update()
    {
        if (swapScene)
        {
            player = null;
            currentRoom = newRoomNumber;
            UnityEngine.SceneManagement.SceneManager.LoadScene(newRoomNumber);
        }
    }

    public void UpdateScene()
    {
        // Instanitate stars
        GameObject stars = Instantiate(Resources.Load<GameObject>("Star"));
        stars.transform.position = new Vector3(0, 0, 100f);

        // Instaniate spawnlocation
        GameObject spawnLoacation = Instantiate(Resources.Load<GameObject>("SpawnLocation"));
        spawnLoacation.name = "SpawnLocation";

        // Gravity Center
        GameObject gravityCenter = Instantiate(new GameObject());
        gravityCenter.name = "Gravity Center";
        gravityCenter.tag = "Gravity Center";

        Destroy(GameObject.Find("Ship"));
        GameObject Ship = Instantiate(Resources.Load<GameObject>("Ship"));
        Ship.name = "Ship";

        spawnPlayer();

        UpdateSceneForCurrentProgress();
    }

    private void spawnPlayer()
    {
        

        player = Instantiate(Resources.Load<GameObject>("Player"));
        player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        player.gameObject.name = "Player";

        if (currentRoom == 0 && firstMesssageRecieved == false)
        {
            Debug.Log("First spawn of player in room 0");
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

            if(player == null)
            {
                player.transform.Find("PlayerPhysics").gameObject.transform.position = new Vector3(
                    GameObject.Find("SpawnLocation").transform.position.x,
                    GameObject.Find("SpawnLocation").transform.position.y,
                    -3f
                );
            }

            door = null;
        }

        player.transform.Find("Main Camera").gameObject.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            -10f
            );


    }

    public void UpdateEvent(bool enterOrExit, GameObject obj)
    {
        if(enterOrExit == true)
        {
            string msg = "";

            if (obj.GetComponent<BaseItem>())
            {
                msg = "Press E to pick up!";
            }

            EnterCollider(this, new InfoEventArgs<GameObject, string>(obj, msg));
        }
            
        else
            ExitCollider(this, new InfoEventArgs<GameObject>(obj));
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            IsPausedEvent(this, new InfoEventArgs<bool>(true));
            Debug.Log("Should pause game");
        }
        else
        {
            IsPausedEvent(this, new InfoEventArgs<bool>(false));
            Debug.Log("Should unpause game");
        }
    }

    public void CompletedATask(GameObject obj, string story, AudioClip clip)
    {
        Debug.Log("Should have completed a task!");
        CompleteTask(obj, new InfoEventArgs<AudioClip, string>(clip, story));
        PauseGame(true);
        power += rewardChargeAmount;
    }

    void UpdateSceneForCurrentProgress()
    {
        RoomFeature[] features = GameObject.FindObjectsOfType<RoomFeature>();
        BaseItem[] items = GameObject.FindObjectsOfType<BaseItem>();

        foreach (RoomFeature obj in features)
        {
            foreach(SO_BaseItem bi in completedTasks)
            {
                if(obj.feature.problem_solver == bi)
                {
                    Debug.Log("*** Found a solution");
                    obj.gameObject.GetComponent<SpriteRenderer>().sprite = obj.feature.SO_Fixed_Image;
                    obj.isFixed = true;
                }
            }
        }

        //Debug.Log("Found " + items.Length + " of items in the room");
        //Debug.Log("Number of completed tasks" + completedTasks.Count);

        foreach (BaseItem item in items)
        {
            
            if (item.item == currentItem)
            {
                Destroy(item.gameObject);
            }

            foreach(SO_BaseItem bi in completedTasks)
            {
                if(item.item == bi)
                {
                    Destroy(item.gameObject);
                }
                else
                {
                    //Debug.Log("Did not delete " + item + " cuz it tried to match with " + bi);
                }
            }
        }
    }

    public void WinCondition()
    {
        Application.LoadLevel(winScene);
    }

    public void Reset()
    {
        completedTasks = new List<SO_BaseItem>();
        currentItem = null;
        power = 100f;
        Debug.Log("Would reset the Game data");
    }
}


