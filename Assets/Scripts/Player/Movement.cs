using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Movement : MonoBehaviour
{
    #region MovementValues
    private KeyCode Left = KeyCode.A, Right = KeyCode.D, Up = KeyCode.Space;

    private Rigidbody2D rb;
    
    public float movementForce = 1, jumpForce = 1;
    #endregion

    #region GorundCheckValues
    private float checkRadius = .05f, jumpTimeCounter , jumpTime = 0.2f;
 
    private bool isGrounded, isJumping;

    public Transform feetPos;

    public LayerMask groundMask;
    #endregion

    #region Initialize
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

     
    }

 void GroundChecker()
    {
        if (isGrounded)
            return;

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundMask);
    }
    #endregion

    #region InputManager
    void Update()
    {
        GroundChecker();

        #region PCInput
#if UNITY_EDITOR
        if (Input.GetKey(Left))
        {
            Move(new Vector2(-movementForce, 0));
        }
        if (Input.GetKey(Right))
        {
            Move(new Vector2(movementForce, 0));
        }

        if (isGrounded && Input.GetKeyDown(Up))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            isGrounded = false;
            Jump();          
        }
        if (Input.GetKey(Up) && jumpTimeCounter > 0 && isJumping)
        {
            jumpTimeCounter -= Time.deltaTime;
            Jump();
        }
        if (Input.GetKeyUp(Up))
        {
            isJumping = false;
        }

#endif
        #endregion
    }
    #endregion

    #region Movement
    void Move(Vector2 movementVector)
    {
        transform.Translate(movementVector * Time.deltaTime);
    }
    void Jump()
    {
        rb.velocity = new Vector2(0, jumpForce) * Time.fixedDeltaTime;
    }
    #endregion

}
