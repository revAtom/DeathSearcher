using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Transform playerFootTransform;

    private float gravityModifier = -9.81f, distanceToGround = 1f;
        
    private Vector2 gravity;
    public LayerMask ground;

    protected bool isGrounded;
     void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerFootTransform.position,distanceToGround, ground);
        print(gravity);
    }
   void FixedUpdate()
    {
        GetInput();
        if (!isGrounded)
        {  
            gravity = new Vector2(0,gravityModifier * Mathf.Sqrt(Time.fixedDeltaTime));
            print(gravity);
            playerRb.velocity = gravity;
        }
    }
    protected virtual void GetInput()
    {

    }
    protected void MoveHorizontal(Vector2 moveVector)
    {
        playerRb.velocity = moveVector - gravity;
    }  
}
