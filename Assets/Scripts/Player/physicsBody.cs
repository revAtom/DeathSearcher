using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsBody : MonoBehaviour
{
    public float minGroundNormaly = .65f;
    public float gravityModifier = 1f;

    protected bool isGrounded;
    protected Vector2 groundNormal;

    protected Vector2 targetVelocity;
    protected Vector2 velocity;
    protected Rigidbody2D rb;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = .001f;
    protected const float shellRadius = .001f;

    #region SetUp
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
     void Update()
    {
        targetVelocity = Vector2.zero;
        MoveInput();
    }
    #endregion

    #region InputGetter
    protected virtual void MoveInput()
    {

    }
    #endregion

    #region GravitySetter
    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        isGrounded = false;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

       move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }
    #endregion

    #region Movement
    void Movement(Vector2 move, bool yMovement )
    {
        float distance = move.magnitude;

        if(distance > minMoveDistance)
        {
          int count = rb.Cast(move, contactFilter, hitBuffer,distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if(currentNormal.y > minGroundNormaly)
                {
                    isGrounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if(projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float mosifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = mosifiedDistance < distance ? mosifiedDistance : distance;
            }
        }

        rb.position = rb.position + move.normalized * distance;
    }
    #endregion
}
