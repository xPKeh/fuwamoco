using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem : MonoBehaviour
{
    private bool falling;
    [SerializeField] private Color changerColor;
    [SerializeField] private Color beforeColor;
    private PlatformEffector2D effector2D;
    private int layerP;
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

    public void PlatformFall(string layerNameP)
    {
        layerP = LayerMask.NameToLayer(layerNameP);
        if (!falling && layerNameP == "Mococo")
        {
            falling = true;
            effector2D.gameObject.layer = LayerMask.NameToLayer("CollRed");
            StartCoroutine(RecuperarPlatform());
        }
        if (!falling && layerNameP == "Fuwawa")
        {
            falling = true;
            effector2D.gameObject.layer = LayerMask.NameToLayer("CollBlue");
            StartCoroutine(RecuperarPlatform());
        }
    }

    IEnumerator RecuperarPlatform()
    {
        sr.color = beforeColor;
        yield return new WaitForSeconds(.7f);
        falling = false;
        sr.color = changerColor;
        effector2D.gameObject.layer = LayerMask.NameToLayer("Platform");
    }
}
