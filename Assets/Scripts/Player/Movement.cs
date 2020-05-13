using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement : physicsBody
{
    #region MovementValues
    private KeyCode Left = KeyCode.A, Right = KeyCode.D, Up = KeyCode.Space;
    
    public float movementForce = 1, jumpForce = 1;

    private SpriteRenderer spriteRenderer;
    #endregion

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void ComputerVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(Up) && isGrounded)
        {
            velocity.y = jumpForce;
        }
        else if (Input.GetKeyUp(Up))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * .5f;
        }
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.001f) : (move.x < 0.001f));

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
     
        targetVelocity = move * movementForce;
    }
}
