using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class SwitchGate : MonoBehaviour
{
    [SerializeField] private Color redColor;
    [SerializeField] private int redLayer;
    [SerializeField] private Color blueColor;
    [SerializeField] private int blueLayer;
    [SerializeField] private GameObject gateToSwitch;
    private SpriteRenderer sr;
    private GameObject player;
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
        if (player != null && player.gameObject.layer == layer)
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
        if(collision.GetComponent<Movement>()) player = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }
}
