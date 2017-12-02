using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]

public class Player : MonoBehaviour
{

    public float accelerationTimeGrounded;

    public float moveSpeed = 6f;
    public float dashForce = 300f;
    private Vector3 velocity;
    private float velocityXSmoothing;

    public float gravity = -20f;

    //dash
    public float dashFrequency = 0.5f;
    private float saveDashFrequency;
    private float counterdashFrequency = 0f;
    private bool canDash;
    
    [HideInInspector]
    public Controller2D controller;

    private Vector2 directionalInput;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<Controller2D>();

        saveDashFrequency = dashFrequency;
        dashFrequency = -1f;
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {



        CalculateVelocity(0);

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.grounded)
        {

            velocity.y = 0f;

        }

        if (dashFrequency == saveDashFrequency)
        {

            counterdashFrequency += Time.deltaTime;
            if (counterdashFrequency >= dashFrequency)
            {
                Debug.Log("canJump = true");
                canDash = true;
                dashFrequency = -1;
                counterdashFrequency = 0f;
                
            }

        }



    }
    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void dashing()
    {
        if (canDash)
        {
            CalculateVelocity(dashForce);
            canDash = false;
            dashFrequency = saveDashFrequency;
        }

            
        
        


    }

    public void CalculateVelocity(float extraMove)
    {


        float targetVelocityX = directionalInput.x * moveSpeed  + extraMove*directionalInput.x;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);
        velocity.y += gravity * Time.deltaTime;
    }
}