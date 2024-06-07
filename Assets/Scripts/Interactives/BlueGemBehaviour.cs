using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    public static event Action OnGotBlueGem = delegate { };

    //con scriptable objects se soluciona el repetir codigo, pasas el numero que quieres y el sprite y fuera.
    //con eso solo tienes que llamar a la funcion, esto afecta a bluegem/redgem.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Movement>())
        {
            OnGotBlueGem();
            ps.Play();
            AudioManager.instance.PlaySFX(AudioManager.instance.pickUp);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.3f);
            //this.gameObject.SetActive(false);
        }
    }
}
