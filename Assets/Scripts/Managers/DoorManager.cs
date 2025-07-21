using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorManager : MonoBehaviour, IDoorManager
{
    public abstract void AddPlayerInDoor(int world, int lvl);
    public abstract void SubPlayerInDoor();

}
