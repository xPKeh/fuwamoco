using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallBehaviour : MonoBehaviour
{
    [SerializeField] private Color changerColor;
    [SerializeField] private Color beforeColor;
    private PlatformEffector2D effector2D;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        effector2D = GetComponent<PlatformEffector2D>();
    }

    public void Fall(GameObject player)
    {
            effector2D.colliderMask -= 1 << player.layer;
            StartCoroutine(RecuperarPlatform(1 << player.layer));
    }

    IEnumerator RecuperarPlatform(int layer)
    {
        sr.color = beforeColor;
        yield return new WaitForSeconds(.7f);
        sr.color = changerColor;
        effector2D.colliderMask += layer;
    }
}