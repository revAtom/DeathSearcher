using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    #region MovementValues
    private KeyCode Left = KeyCode.A, Right = KeyCode.D, Up = KeyCode.Space;

    private Rigidbody2D rb;
    
    public float movementForce = 1, jumpForce = 1;
    #endregion

    #region GorundCheckValues
    private float checkRadius = .05f, jumpTimeCounter , jumpTime = 0.2f;
 
  
    private bool isGrounded, isJumping, isLeft , isRight, isJump;

    public Transform feetPos;

    public LayerMask groundMask;
    #endregion

}
