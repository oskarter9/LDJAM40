using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]

public class Player : MonoBehaviour
{

    public PlayerCommonStats PlayerStats;
    
    private Vector3 _velocity;
    private float _velocityXSmoothing;

    //dash
    private float _saveDashFrequency;
    private float _counterdashFrequency = 0f;
    private bool _canDash;
    private Controller2D _controller;
    private Vector2 _directionalInput;


    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<Controller2D>();

        _saveDashFrequency = PlayerStats.dashFrequency;
        PlayerStats.dashFrequency = -1f;
        _canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVelocity(0);

        _controller.Move(_velocity * Time.deltaTime, _directionalInput);

        if (_controller.collisions.grounded)
        {
            _velocity.y = 0f;
        }

        if (Math.Abs(PlayerStats.dashFrequency - _saveDashFrequency) < 0.01)
        {
            _counterdashFrequency += Time.deltaTime;
            if (_counterdashFrequency >= PlayerStats.dashFrequency)
            {
                Debug.Log("canJump = true");
                _canDash = true;
                PlayerStats.dashFrequency = -1;
                _counterdashFrequency = 0f;
            }
        }
    }
    
    public void SetDirectionalInput(Vector2 input)
    {
        _directionalInput = input;
    }

    public void Dashing()
    {
        if (_canDash)
        {
            CalculateVelocity(PlayerStats.dashForce);
            _canDash = false;
            PlayerStats.dashFrequency = _saveDashFrequency;
        }

    }

    public void CalculateVelocity(float extraMove)
    {

        float targetVelocityX = _directionalInput.x * PlayerStats.moveSpeed  + extraMove*_directionalInput.x;
        _velocity.x = Mathf.SmoothDamp(_velocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerStats.accelerationTimeGrounded);
        _velocity.y += PlayerStats.gravity * Time.deltaTime;
    }
}