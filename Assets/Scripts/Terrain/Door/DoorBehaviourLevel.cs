using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorBehaviourLevel : MonoBehaviour
{
    void OnEnable()
    {
        PickUpManager.OnDoorPickUpUpdate += CheckDoor;
    }

    void OnDisable()
    {
        PickUpManager.OnDoorPickUpUpdate -= CheckDoor;
    }

    private void Start()
    {
        Manager.instance.DoorManager.GetComponent<IDoorManager>().SubPlayerInDoor();
    }
    public void CheckDoor(Dictionary<int, DataStructures.spritePair> doorCheck)
    {
        bool tempCount = true;
        foreach (int key in doorCheck.Keys)
        {
            if (doorCheck[key].value != 0) tempCount = false;            
        }

        if (doorCheck[this.gameObject.layer].value == 0) this.GetComponent<StatusDoorInfo>().active = true;
        this.GetComponent<StatusDoorInfo>().open = tempCount;
    }
}
