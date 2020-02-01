using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_RoomFeature : ScriptableObject
{
    public string name;
    public Enum_Terrains terrain;
    public SO_BaseItem problem_solver;
    public Sprite SO_Sprite;
    public int SO_Door_NextRoom;
}
