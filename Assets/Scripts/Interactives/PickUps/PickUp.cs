using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void Awake()
    {
        Manager.instance.addDoorPickUp(this.gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
        {
            Manager.instance.subDoorPickUp(this.gameObject);
            AudioManager.instance.PlaySFX(AudioManager.instance.pickUp);
            this.gameObject.SetActive(false);
        }
    }
}
