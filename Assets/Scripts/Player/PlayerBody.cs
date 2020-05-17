using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Rigidbody2D playerRb;

    private float gravityModifier = 50f;

    Vector2 gravity;

    public LayerMask ground;
    bool isGround;
     void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();    
    }
    void Update()
    {

    }
   void FixedUpdate()
    {
        if (!isGround)
        {
            gravity = new Vector2(0, gravityModifier * Mathf.Sqrt(Time.fixedDeltaTime));
            playerRb.velocity = -gravity;
            Debug.Log(gravity);
        }
     //   playerRb.velocity = Vector2.left - gravity;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == ground)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
