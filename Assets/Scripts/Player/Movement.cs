using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement : PlayerBody
{
    #region MovementValues

    public float movementForce = 1, jumpForce = 1;

   Vector2 move;

    public Animator playerAnim;
    public SpriteRenderer spriteRenderer;
    #endregion

    protected override void GetInput()
    {
        AnimSetter();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveHorizontal(Vector2.left * movementForce);
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            MoveHorizontal(Vector2.right * movementForce);
        }
        if (!(Input.anyKey))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shoot();
        }

    /*    if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * .5f;
        }*/
#endif
        bool sideChecker = (spriteRenderer.flipX ? (move.x > 0.0001f) : (move.x < -0.0001f));


        if (sideChecker)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
     

    }
    void Shoot()
    {

    }
   void AnimSetter()
    {
        bool isNowRunning = ((move.x != 0) ? true : false);

        playerAnim.SetBool("isRun", isNowRunning);

        playerAnim.SetBool("isJump", !isGrounded);
    }    
}
