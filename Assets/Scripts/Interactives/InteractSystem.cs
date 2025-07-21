using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractSystem : MonoBehaviour
{
     private IInteractuableTriggerBehaviour ItemSlot;
    //button interact.
    public void Interact(InputAction.CallbackContext context)
    {

        if (context.performed  && IsTouched())
        {

            ItemSlot.Interact(this.gameObject);
        }
    }

    public void setItem(IInteractuableTriggerBehaviour itb)
    {
        if (ItemSlot == null)  
            ItemSlot = itb;
        
    }
    public void emptyItem()
    {
        ItemSlot = null;
    }
    public void emptyItem(IInteractuableTriggerBehaviour itb)
    {
        if (ItemSlot == itb) emptyItem();
    }
    public bool IsTouched()
    {
        RaycastHit2D result = this.GetComponent<GroundDetector>().GetInteractuable();
        if (result)
        {
            result.collider.TryGetComponent(out IInteractuableTriggerBehaviour itb);
            setItem(itb);
            return true;
        }
        return false;
    }

}
