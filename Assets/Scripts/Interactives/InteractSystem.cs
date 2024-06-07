using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractSystem : MonoBehaviour
{
    private BoxCollider2D bc;
    public int layer;
    [SerializeField] private LayerMask interactable;

    public static event Action<int> OnInteract = delegate { };

    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        layer = gameObject.layer;
    }

    //button interact.
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && IsTouched())
        {
            OnInteract(layer);
        }
    }

    public bool IsTouched()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.left, 0f, interactable);
    }
}
