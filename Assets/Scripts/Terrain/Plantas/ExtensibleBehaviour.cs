using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensibleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ps;
    private void OnCollisionEnter2D(Collision2D collision)
    {        
       if (collision.gameObject.tag.Equals("Fireboy"))
        {

            ps.GetComponent<ParticleSystem>().Play();
            AudioManager.instance.PlaySFX(AudioManager.instance.plantBurn);
            GetComponentInParent<PlantaBehaviour>().Burn();
        }
    }

    
}
