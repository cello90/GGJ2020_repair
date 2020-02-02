using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public List<AudioClip> clips;

    //public SO_BaseItem item;
    [SerializeField] private Collider2D hittingACollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("L_E") > 0)
        {
            Debug.Log("Tried to interact...");

            // If Colliders exist
            if(hittingACollider != false && hittingACollider != null)
            {
                // Room Feature code
                RoomFeature featureObject = hittingACollider.gameObject.GetComponent<RoomFeature>();

                if (featureObject)
                {
                    if (featureObject.feature.feature_enum == Enum_Feature.Door)
                    {
                        CheckRoomData(featureObject);
                    }
                }

                // Base Item Code
                BaseItem baseItem = hittingACollider.gameObject.GetComponent<BaseItem>();

                if (baseItem && Game.instance.currentItem == null)
                {
                    Game.instance.currentItem = baseItem.item;
                    Debug.Log("Player destroying item...");
                    Destroy(hittingACollider.gameObject);
                }

                else if (baseItem && Game.instance.currentItem != null)
                {
                    // Get new item
                    SO_BaseItem tmpItem = baseItem.item;

                    // Reset existing item
                    baseItem.item = Game.instance.currentItem;
                    baseItem.UpdateSprite();

                    // Set this scripts item
                    Game.instance.currentItem = tmpItem;
                    Debug.Log("Player destroying item...");
                }

            }
            else
            {
                Debug.Log("No interactions");
            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Should drop the item...");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hittingACollider = collision;
        Game.instance.UpdateEvent(true, collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hittingACollider = null;
        Game.instance.UpdateEvent(false, collision.gameObject);
    }

    private void CheckRoomData(RoomFeature featureObject)
    {
        if (featureObject.feature.problem_solver == null || featureObject.feature.problem_solver == false)
        {
            if (featureObject.feature.feature_enum == Enum_Feature.Door)
            {
                MoveRoom(featureObject);
            }
        }

        else if (featureObject.feature.problem_solver == Game.instance.currentItem)
        {
            Debug.Log("Should execute... Feature type: " + featureObject.feature.feature_enum.ToString());
            if (featureObject.feature.feature_enum == Enum_Feature.Door)
            {
                MoveRoom(featureObject);
                Game.instance.completedTasks.Add(Game.instance.currentItem);
            }
        }
    }

    private void MoveRoom(RoomFeature featureObject)
    {
        //if (clips.Count > 0)
        //    Game.instance.music.SetMusic(clips[Random.Range(0,clips.Count)]);

        Debug.Log("Should send to another room...");

        if (featureObject.feature == null || featureObject.feature == false)
            Debug.LogError("Should have a door assigned to the Game Object: " + this.name);



        Game.instance.door = featureObject.feature;
        Game.instance.LoadScene(featureObject.feature.SO_Door_NextRoom);        
    }
}
