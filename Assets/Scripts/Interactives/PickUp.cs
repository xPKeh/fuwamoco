using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.pickUp);
            this.gameObject.SetActive(false);
        }
    }
}
