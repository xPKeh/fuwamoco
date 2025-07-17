using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableTriggerBehaviourDynamic : MonoBehaviour, IInteractuableTriggerBehaviour
{
    public GameObject parent;

    public void Interact(GameObject player) {
        if (parent == null || parent != player) {
            Debug.Log(player.name);
            Grab(player); }
        else Release();    
    }
    private void Grab(GameObject playerInteractuableSlot)
    {
        if (parent != null) parent.GetComponent<InteractSystem>().emptyItem();
        parent = playerInteractuableSlot;
        playerInteractuableSlot.GetComponent<InteractSystem>().setItem(this);
        GetComponentInParent<IInteractuableBehaviour>().SetParentInteractuable(playerInteractuableSlot);
    }

    private void Release()
    {
        parent.GetComponent<InteractSystem>().emptyItem();
        parent = null;
        GetComponentInParent<IInteractuableBehaviour>().RemoveParentInteractuable();
    }
}
