using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviourSelector : MonoBehaviour
{
    [SerializeField] private int saveLvl = 0;

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
        if (this.GetComponent<StatusDoorInfo>().indexDoorLvl <= saveLvl) this.GetComponent<StatusDoorInfo>().open = true;
    }
}
