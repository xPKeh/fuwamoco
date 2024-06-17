using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class SwitchGate : MonoBehaviour
{
    [SerializeField] private Color redColor;
    [SerializeField] private int redLayer;
    private bool isMococo = false;
    [SerializeField] private Color blueColor;
    [SerializeField] private int blueLayer;
    private bool isFuwawa = false;
    [SerializeField] private GameObject gateToSwitch;
    private SpriteRenderer sr;
    private string playerL;
    [SerializeField] private string layer;

    private void Awake()
    {
        sr = gateToSwitch.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InteractSystem.OnInteract += OnSwitchGate;
    }

    private void OnDisable()
    {
        InteractSystem.OnInteract -= OnSwitchGate;
    }

    public void OnSwitchGate(int layer)
    {
        if ((isMococo && LayerMask.NameToLayer("Mococo") == layer) || (isFuwawa && LayerMask.NameToLayer("Fuwawa") == layer))
        {
            if (gateToSwitch.layer == redLayer)
            {
                gateToSwitch.layer = blueLayer;
                sr.color = blueColor;
            }
            else
            {
                gateToSwitch.layer = redLayer;
                sr.color = redColor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mococo")) isMococo = true;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fuwawa")) isFuwawa = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mococo")) isMococo = false;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fuwawa")) isFuwawa = false;
    }
}
