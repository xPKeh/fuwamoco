using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviourSelector : MonoBehaviour
{

    //el comentado es el que usaremos cuando el save este listo, el que estamos usando es donde estan ahora mismo la gestion de estos datos.
    void OnEnable()
    {
        //SaveManager.OnDoorPickUpUpdate += CheckDoor;
        PickUpManager.OnDoorPickUpUpdate += CheckDoor;
    }

    void OnDisable()
    {
        //SaveManager.OnDoorPickUpUpdate -= CheckDoor;
        PickUpManager.OnDoorPickUpUpdate -= CheckDoor;
    }


    public void CheckDoor(Dictionary<int, DataStructures.spritePair> statusDoor)
    {
        int thisDoorLevel = this.GetComponent<StatusDoorInfo>().indexDoorLvl;
        int maxCompletedLevelInCurrentWorld = SaveFileManager.instance.GetSaveData().completedLevels.Lvl;

        //Implicitamente el World de la save file debe ser igual o superior al de la escena asi que no hace falta comparar
        if (thisDoorLevel <= maxCompletedLevelInCurrentWorld + 1) this.GetComponent<StatusDoorInfo>().open = true;
    }
}
