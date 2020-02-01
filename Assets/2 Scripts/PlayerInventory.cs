using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public SO_BaseItem item;
    [SerializeField] private Collider2D hittingACollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tried to interact...");
            if(hittingACollider != false && hittingACollider != null)
            {
                RoomFeature featureObject = hittingACollider.gameObject.GetComponent<RoomFeature>();
                
                if(featureObject.feature.problem_solver == null || featureObject.feature.problem_solver == false)
                {
                    if(featureObject.feature.feature_enum == Enum_Feature.Door)
                    {
                        MoveRoom(featureObject);
                    }
                }
                
                else if (featureObject.feature.problem_solver == item)
                {
                    Debug.Log("Should execute... Feature type: " + featureObject.feature.feature_enum.ToString());
                    if(featureObject.feature.feature_enum == Enum_Feature.Door)
                    {
                        MoveRoom(featureObject);
                    }
                }
            }
            else
            {
                Debug.Log("No interactions");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hittingACollider = collision;

        if (hittingACollider.gameObject.GetComponent<BaseItem>() && item == null)
        {
            item = hittingACollider.gameObject.GetComponent<BaseItem>().item;
            Debug.Log("Player destroying item...");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hittingACollider = null;
    }

    private void MoveRoom(RoomFeature featureObject)
    {
        Debug.Log("Should send to another room...");
        Game.instance.LoadScene(featureObject.feature.SO_Door_NextRoom);
    }
}
