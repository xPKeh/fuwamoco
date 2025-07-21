using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorMenuManager : DoorManager
{
    private void Awake()
    {
        Manager.instance.DoorManager = this;
    }

    //Resta 1 al contador de puertas que llenar con players, cuando este llega a 0 puertas se cambia de escena
    public override void AddPlayerInDoor(int world, int lvl)
    {
        Debug.Log("dentro del addplayer in door");
        
        //if (Manager.instance.InfoManager.IsDoorOpen()
        Manager.instance.loadLevelScene(world, lvl); //SceneManager siguiente escena/lobby
    }

    //Añade 1 al contador de puertas que llenar con players
    public override void SubPlayerInDoor()
    {

    }
}
