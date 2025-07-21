using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask platformGround;
    [SerializeField] private LayerMask interactuable;
    [SerializeField] BoxCollider2D bc;

    //Se asume que el BoxCollider2D que se utiliza esté centrado en el objeto, 
    //si no lo fuera se recomienda añadir un BoxCollider2D centrado y desactivarlo
    public bool IsGrounded()
    {
        Vector2 centroBase = new Vector2(bc.bounds.center.x, bc.bounds.min.y + .05f);
        //Debug.Log(Physics2D.BoxCast(centroBase, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, .01f, jumpableGround).collider != null);
        return Physics2D.BoxCast(centroBase, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, .1f, jumpableGround);//.collider != null;
    }
    //Devuelve cierto si 0.05f debajo del objeto hay terreno que coincide con la layermask de jumpableGround

    public bool IsPlatform()
    {
        Vector2 centroBase = new Vector2(bc.bounds.center.x, bc.bounds.min.y + .05f);
        //Debug.Log(Physics2D.BoxCast(centroBase, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, .01f, platformGround).collider != null);
        return Physics2D.BoxCast(centroBase, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, .1f, platformGround);//.collider != null;
    }

    public RaycastHit2D GetPlatform()
    {
        Vector2 centroBase = new Vector2(bc.bounds.center.x, bc.bounds.min.y + .05f);
        //Debug.Log(Physics2D.BoxCast(centroBase, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, .01f, platformGround).collider != null);
        return Physics2D.BoxCast(centroBase, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, .1f, platformGround);//.collider != null;}
    }

    public RaycastHit2D GetInteractuable()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.left, 0f, interactuable);
    }
}
