using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractuableDoorBehaviour
{
    void CheckDoor(Dictionary<int, DataStructures.spritePair> doorManagementDictionary);
    bool GetOpen();
    bool GetActive();
}
