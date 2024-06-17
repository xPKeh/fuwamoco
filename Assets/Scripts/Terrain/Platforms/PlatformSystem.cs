using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem : MonoBehaviour
{
    private bool falling;
    [SerializeField] private Color changerColor;
    [SerializeField] private Color beforeColor;
    private PlatformEffector2D effector2D;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        effector2D = GetComponent<PlatformEffector2D>();
    }

    private void Start()
    {
        falling = false;
    }
    private void OnEnable()
    {
        Movement.OnFall += PlatformFall;
    }

    private void OnDisable()
    {
        Movement.OnFall -= PlatformFall;
    }

    private void FixedUpdate()
    {
        //if (PlatformExit() && !gameObject.GetComponentInChildren<Transform>()) gameObject.GetComponentInChildren<Transform>().SetParent(null);
    }

    //tiene lo mismo en los 2 parametros no tiene sentido, algo no se esta calculando bien.
    public bool PlatformExit()
    {
        //Debug.Log("posicion hijo: ");
        //Debug.Log(gameObject.GetComponentInChildren<Transform>().position.y);
        //Debug.Log("posicion padre: ");
        //Debug.Log(gameObject.transform.position.y);
        return gameObject.GetComponentInChildren<Transform>().position.y < gameObject.transform.position.y + 2.3f;
    }

    public void PlatformFall(int layerNameP)
    {
        if (layerNameP == LayerMask.NameToLayer("Mococo"))
        {
            effector2D.colliderMask -= 1 << 7;
            StartCoroutine(RecuperarPlatform(1 << 7));
        }
        if (layerNameP == LayerMask.NameToLayer("Fuwawa"))
        {
            effector2D.colliderMask -= 1 << 6;
            StartCoroutine(RecuperarPlatform(1 << 6));
        }
    }

    IEnumerator RecuperarPlatform(int layer)
    {
        sr.color = beforeColor;
        yield return new WaitForSeconds(.7f);
        falling = false;
        sr.color = changerColor;
        effector2D.colliderMask += layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>().IsPlatform() && collision.transform.parent == null) collision.transform.SetParent(this.transform);
        //Debug.Log(collision.transform.parent);
        if (collision.GetComponent<GrabbableSystem>() && collision.transform.parent == null) collision.transform.SetParent(this.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("trigger exit");
        if (!collision.GetComponent<Movement>().IsPlatform()) collision.transform.SetParent(null);
    }
}
