using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGemBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    public static event Action OnGotRedGem = delegate { };
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Movement>()) 
        {
            OnGotRedGem();
            ps.Play();
            AudioManager.instance.PlaySFX(AudioManager.instance.pickUp);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.3f);
            
            //this.gameObject.SetActive(false); 
        }
    }
}
