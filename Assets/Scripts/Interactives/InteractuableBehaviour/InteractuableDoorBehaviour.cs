using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableDoorBehaviour : MonoBehaviour, IInteractuableBehaviour
{
    public bool player = false;

    void IInteractuableBehaviour.Act()
    { }

    void IInteractuableBehaviour.Act(GameObject PlayerObject) {

        Debug.Log(this.gameObject.layer);
        Debug.Log(PlayerObject.layer);
        if (this.GetComponent<StatusDoorInfo>().open)
        {
            player = !player;
            if (player)
            {
                PlayerObject.transform.position = this.transform.position;
                PlayerObject.GetComponent<Movement>().disableMovement();
                Debug.Log(this.GetComponent<StatusDoorInfo>().indexDoorWorld);
                Debug.Log(this.GetComponent<StatusDoorInfo>().indexDoorLvl);
                Manager.instance.DoorManager.GetComponent<IDoorManager>().AddPlayerInDoor(
                    this.GetComponent<StatusDoorInfo>().indexDoorWorld, 
                    this.GetComponent<StatusDoorInfo>().indexDoorLvl);
            }

            else
            {
                PlayerObject.GetComponent<Movement>().enableMovement();
                Manager.instance.GetComponentInChildren<IDoorManager>().SubPlayerInDoor();
            }
            // Bloquear Player
        }
    }

    void IInteractuableBehaviour.RemoveParentInteractuable()
    {
        throw new System.NotImplementedException();
    }

    void IInteractuableBehaviour.SetParentInteractuable(GameObject playerInteractuableSlot)
    {
        throw new System.NotImplementedException();
    }
}
