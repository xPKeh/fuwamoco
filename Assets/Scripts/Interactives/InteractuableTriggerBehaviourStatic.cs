using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableTriggerBehaviourStatic : MonoBehaviour, IInteractuableTriggerBehaviour
{
    [SerializeField] private GameObject Player = null;
    
    public void Interact(GameObject player)
    {
        Player = player; 
        this.GetComponentInParent<IInteractuableBehaviour>().Act();
        this.GetComponentInParent<IInteractuableBehaviour>().Act(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.GetComponent<InteractSystem>().emptyItem(this);
            Player = null;
        }
    }



}
