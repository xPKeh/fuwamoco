using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask platformGround;
    [SerializeField] private LayerMask wallGround;
    [SerializeField] private PhysicsMaterial2D noFriction;
    [SerializeField] private PhysicsMaterial2D normalFriction;

    public static event Action<int> OnFall = delegate { };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        OnAir();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();

    //when event is triggered convert that data in vector2 to work with data. 
    public void Move()
    {
        // Swap direction of sprite depending on walk direction.
        if (movementInput.x > 0)
        {
            //state for animations.
            //anim.set.runing;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if (movementInput.x < 0)
        {
            //state for animations.
            //anim.set.runing;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        else
        {
            //state for animations.
            //anim.set.idleing;
        }

        //move.
        rb.velocity = new Vector2(movementInput.x * speed, rb.velocity.y);
    }

    //when event is triggered does whatever is in function.
    public void Jump(InputAction.CallbackContext context)
    {
        //jump.
        if(context.performed && (IsGrounded() || IsPlatform()))
        {
            //state for animations.
            //if (rb.velocity.y > .1f) anim.set.jumping;
            //if (rb.velocity.y < -.1f) anim.set.falling;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            AudioManager.instance.PlaySFX(AudioManager.instance.jump);
        }
    }

    public void Fall(InputAction.CallbackContext context)
    {
        if (context.performed && IsPlatform())
        {
            gameObject.transform.SetParent(null);
            OnFall(gameObject.layer);
        }
    }

    //set frictions on player when player was on air or touching ground, if that was necesary, player need to see how to don't get more friction of walls.
    public void OnAir()
    {
        if(IsGrounded() || IsPlatform())
        {
            bc.sharedMaterial = normalFriction;
            if (IsWall())
            {
                bc.sharedMaterial = noFriction;
            }
        }
        else
        {
            bc.sharedMaterial = noFriction;
        }
    }

    //check if player are touching ground.
    public bool IsGrounded()
    {
        //no le gusta con el raycast, hay que mirar que le pasa.
        //return Physics2D.Raycast(bc.bounds.min, Vector2.down, .1f);
        return Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, bc.bounds.extents.y, jumpableGround);
        //(bc.bounds.size * Vector2.right) + new Vector2(-0.01f,0.1f) 
    }

    public bool IsPlatform()
    {
        return Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, bc.bounds.extents.y, platformGround);
    }

    public bool IsWall()
    {
        return Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x + 0.1f, 0.1f), 0f, Vector2.down, bc.bounds.extents.y/2, wallGround);
    }

    private void OnDrawGizmos()
    {
        //Ground collider 
        Gizmos.color = Color.cyan;

        //left.
        Gizmos.DrawRay (new Vector3 (bc.bounds.center.x - bc.bounds.extents.x, bc.bounds.center.y - bc.bounds.extents.y - 0.1f), Vector3.up * .2f);
        //bottom.
        Gizmos.DrawRay(new Vector3 (bc.bounds.center.x - bc.bounds.extents.x, bc.bounds.center.y - bc.bounds.extents.y - 0.1f), new Vector2 (bc.bounds.size.x, 0));
        //right.
        Gizmos.DrawRay(new Vector3(bc.bounds.center.x + bc.bounds.extents.x, bc.bounds.center.y - bc.bounds.extents.y - 0.1f), Vector3.up * .2f);
        //up.
        Gizmos.DrawRay(new Vector3(bc.bounds.center.x - bc.bounds.extents.x, bc.bounds.center.y - bc.bounds.extents.y + 0.1f), new Vector2(bc.bounds.size.x, 0));


        //Wall collider
        Gizmos.color = Color.red;

        //left.
        Gizmos.DrawRay(new Vector3(bc.bounds.center.x - bc.bounds.extents.x - .1f, bc.bounds.center.y - bc.bounds.extents.y/2 - 0.1f), Vector3.up * .2f);
        //bottom.
        Gizmos.DrawRay(new Vector3(bc.bounds.center.x - bc.bounds.extents.x - .1f, bc.bounds.center.y - bc.bounds.extents.y/2 - 0.1f), new Vector2(bc.bounds.size.x + .2f, 0));
        //right.
        Gizmos.DrawRay(new Vector3(bc.bounds.center.x + bc.bounds.extents.x + .1f, bc.bounds.center.y - bc.bounds.extents.y/2 - 0.1f), Vector3.up * .2f);
        //up.
        Gizmos.DrawRay(new Vector3(bc.bounds.center.x - bc.bounds.extents.x - .1f, bc.bounds.center.y - bc.bounds.extents.y/2 + 0.1f), new Vector2(bc.bounds.size.x + .2f, 0));
    }
}