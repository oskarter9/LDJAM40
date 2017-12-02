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

        VerticalCollisions(ref moveAmount);
        transform.Translate(moveAmount);

    }
    private void VerticalCollisions(ref Vector2 moveAmount)
    {

        float directionY = Mathf.Sign(moveAmount.y);

        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;

        

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);

            if (hit)
            {
                Debug.Log("colliding");
                
                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

            }

            collisions.grounded = directionY == -1;

        }
    }
    public struct CollisionInfo
    {

        public bool grounded;
        public int faceDirection;
        
        public void Reset()
        {

            grounded = false;
            
        }


    }
}
