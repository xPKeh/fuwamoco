using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableSystem : MonoBehaviour
{
    private BoxCollider2D bc;
    [SerializeField] LayerMask placeableGround;
    [SerializeField] LayerMask placeablePlatform;
    private Transform player;
    private Rigidbody2D rb;

    private void Awake()
    {
        bc = GetComponents<BoxCollider2D>()[0];
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        InteractSystem.OnInteract += OnGrabItem;
    }

    private void OnDisable()
    {
        InteractSystem.OnInteract -= OnGrabItem;
    }

    public void FixedUpdate()
    {

        if (IsGrounded() && this.gameObject.transform.parent == null) GetComponents<BoxCollider2D>()[1].enabled = true;
        else if (this.gameObject.transform.parent != null && IsPlatform())
        {
            Destroy(rb);
            GetComponents<BoxCollider2D>()[1].enabled = true;
            
        }
        else
        {
            GetComponents<BoxCollider2D>()[1].enabled = false;


        }
    }

    public void OnGrabItem(int layer)
    {
        //hay que hacer debug de lo que se pasa y como, ahora esta colisionando player que tedria que ser gameobject con el transform de un hijo del player que se usa para colocar el objeto.
        if(player != null && player.gameObject.layer == layer)
        {
            if (this.gameObject.transform.parent == null || IsPlatform()) 
            {
                Debug.Log(player);
                GetComponents<BoxCollider2D>()[1].enabled= false;
                Destroy(rb);
                this.gameObject.transform.SetParent(player);
                this.gameObject.transform.position = player.position;
            }
            else
            {             
                this.gameObject.AddComponent<Rigidbody2D>();
                rb = GetComponent<Rigidbody2D>();
                rb.freezeRotation = true;
                this.gameObject.transform.SetParent(null);
                //this.gameObject.transform.position += new Vector3(0f, -.55f);
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x - 0.01f, 0.1f), 0f, Vector2.down, bc.bounds.extents.y, placeableGround); 
    }
    public bool IsPlatform()
    {
        return Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x - 0.01f, 0.1f), 0f, Vector2.down, bc.bounds.extents.y, placeableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>()) player = collision.GetComponentsInChildren<Transform>()[1];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(this.gameObject.transform.parent == null) player = null;
        Debug.Log(player);
    }
}
