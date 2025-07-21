using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableGrabbableBehaviour : MonoBehaviour, IInteractuableBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetParentInteractuable(GameObject playerInteractuableSlot)
    {
        Destroy(rb);

        this.gameObject.transform.SetParent(playerInteractuableSlot.transform);
        this.gameObject.transform.position = playerInteractuableSlot.transform.position + offset;
    }

    public void RemoveParentInteractuable()
    {
        this.gameObject.AddComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        this.gameObject.transform.SetParent(null);
    }

    public void Act() { }
    void IInteractuableBehaviour.Act(GameObject PlayerObject) { }
}
