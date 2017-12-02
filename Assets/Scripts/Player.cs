using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]

public class Player : MonoBehaviour
{

    private float accelerationTimeGrounded;

    public float moveSpeed = 6f;
    private Vector3 velocity;
    private float velocityXSmoothing;

    public float gravity = -20f;

    private Controller2D controller;
    private Vector2 directionalInput;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<Controller2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVelocity();

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.grounded)
        {

            velocity.y = 0f;

        }



    }
    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }
    private void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);
        velocity.y += gravity * Time.deltaTime;
    }
}