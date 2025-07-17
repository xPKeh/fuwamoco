using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoorManager
{
    public void AddPlayerInDoor(int world, int lvl);
    public void SubPlayerInDoor();
}
