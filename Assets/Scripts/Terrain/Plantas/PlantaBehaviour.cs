using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject planta;
    public bool extendido = false;
   

    public float MaxDistancia = 10;
    // Start is called before the first frame update

    //una vez tengas la animacion quitas el update y que vaya dentro de grow/burn.
    private void Update()
    {
        if (extendido && planta.GetComponent<SpriteRenderer>().size.y < MaxDistancia)
        {
            //planta.transform.position = new Vector3( 0, planta.transform.position.y + (.01f / 2), 0);
            //planta.transform.localScale = new Vector3 ( .9f, planta.transform.localScale.y + .01f, .9f);
            
                //esto tienes que hacerle animacion en vez de pasarle numeros por y o x.
                planta.GetComponent<SpriteRenderer>().size = new Vector3(.9f, planta.GetComponent<SpriteRenderer>().size.y + .01f, .9f);
                planta.GetComponent<SpriteRenderer>().gameObject.transform.position = new Vector3(gameObject.transform.position.x, planta.transform.position.y + (.01f / 2), gameObject.transform.position.z);
            
        }

        if (!extendido)
        {
            planta.GetComponent<SpriteRenderer>().size = new Vector3(.9f,.9f, .9f);
            planta.GetComponent<SpriteRenderer>().gameObject.transform.position = gameObject.transform.position;
        }
        planta.GetComponent<BoxCollider2D>().size = planta.GetComponent<SpriteRenderer>().size;
        planta.GetComponent<BoxCollider2D>().transform.position = planta.GetComponent<SpriteRenderer>().gameObject.transform.position;
    }

    //esto tendra que estar en funciones separadas, si lo tienes por separado la deteccion es de una sola layer, la del player que haga grow para ese y el del burn para su respectivo.
    public void Grow()
    {
        extendido = true;
        planta.SetActive(true);
    }

    public void Burn()
    {
        extendido = false;
        planta.SetActive(false);
    }

    //pon un trigger y el collider ya veras como lo metes con el resto del terreno, importante hacer minimo que tenga un trigger.
    //el trigger tendras que poner uno en cada funcion de grow/burn, tendras uqe crear 2 layers para tener de hijos a burn/grow y asi solo tendra que colisionar y ya ejecuta funcion.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Watergirl")) 
        {
            Grow(); 
        }
        else if (collision.gameObject.tag.Equals("Fireboy"))
        {
            Burn();
        }
    }
}
