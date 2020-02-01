using UnityEngine;
using UnityEditor;

public class YourClassAsset {
    ///
    /// Base class for automating the creation of scriptable objects
    ///

    [MenuItem("Assets/Create/Repair/Base Item")]
    public static void CreateNewItem()
    {
        ScriptableObjectUtility.CreateAsset<SO_BaseItem>();
    }

    [MenuItem("Assets/Create/Repair/Room Feature")]
    public static void CreateNewRoomFeature()
    {
        ScriptableObjectUtility.CreateAsset<SO_RoomFeature>();
    }

}