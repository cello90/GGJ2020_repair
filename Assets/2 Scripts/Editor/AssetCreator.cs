﻿using UnityEngine;
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

    [MenuItem("Assets/Create/Repair/Terrain")]
    public static void CreateNewTerrain()
    {
        ScriptableObjectUtility.CreateAsset<SO_Terrain>();
    }

}