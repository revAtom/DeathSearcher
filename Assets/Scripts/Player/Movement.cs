using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement : physicsBody
{
    #region MovementValues

    public float movementForce = 1, jumpForce = 1;

   Vector2 move;

    public Animator playerAnim;
    public SpriteRenderer spriteRenderer;
    private CapsuleCollider2D playerColider;
    #endregion
     void Awake()
    {
        playerColider = GetComponent<CapsuleCollider2D>();    
    }
    protected override void MoveInput()
    {
        AnimSetter();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            move.x = -1f;     
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            move.x = 1f;
        }
        if (!(Input.anyKey))
        {
            move = Vector2.zero;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * .5f;
        }
#endif
        bool sideChecker = (spriteRenderer.flipX ? (move.x > 0.0001f) : (move.x < -0.0001f));

     if (spriteRenderer.flipX)
            {
                playerColider.offset = new Vector2(.07f, 0);
            }
      else {
       playerColider.offset = new Vector2(-.07f, 0);
      }


        if (sideChecker)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
     
        targetVelocity = move * movementForce;
    }
   void AnimSetter()
    {
        bool isNowRunning = ((move.x != 0) ? true : false);

        playerAnim.SetBool("isRun", isNowRunning);

        playerAnim.SetBool("isJump", !isGrounded);
    }
   
}
