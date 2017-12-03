using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : RaycastController {

    public CollisionInfo collisions;
    public Vector2 playerInput;
	// Use this for initialization
	public override void Start () {
        base.Start();
        collisions.faceDirection = 1;
        
	}
	
	// Update is called once per frame
	void Update () {

        
        //Debug.Log(collisions.grounded);
	}

    public void Move(Vector2 moveAmount)
    {

        Move(moveAmount, Vector2.zero);

    }
    public void Move(Vector2 moveAmount, Vector2 input)
    {

        UpdateRaycastOrigins();
        collisions.Reset();
        playerInput = input;

        if (moveAmount.x != 0)
        {
            collisions.faceDirection = (int)Mathf.Sign(moveAmount.x);
        }

        HorizontalCollisions(ref moveAmount);

        if (moveAmount.y != 0)
        {
            VerticalCollisions(ref moveAmount);
        }
        
        
        transform.Translate(moveAmount);

    }
    private void VerticalCollisions(ref Vector2 moveAmount)
    {

        float directionY = Mathf.Sign(moveAmount.y);

        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;

        

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);

            if (hit)
            {
                //Debug.Log("colliding");
                
                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;
                collisions.grounded = directionY == -1;
            }

            
            //Debug.Log(directionY);
           //Debug.Log(collisions.grounded);
        }
    }

    private void HorizontalCollisions(ref Vector2 moveAmount)
    {

        float directionX = collisions.faceDirection;
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
        {
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX, Color.blue);

            if (hit)
            {

                if (hit.distance == 0)
                {
                    continue;

                }

                moveAmount.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;

                collisions.left = directionX == -1;
                collisions.right = directionX == 1;

            }


        }


    }
    public struct CollisionInfo
    {

        public bool grounded;

        public bool left, right;

        public int faceDirection;
        
        public void Reset()
        {

            grounded = false;

            right = false;
            left = false;
        }


    }
}
