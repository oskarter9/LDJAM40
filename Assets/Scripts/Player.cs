using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = 0.4f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = 0.25f;
    private float timeToWallUnstick;

    private float _maxJumpVelocity;
    private float _minJumpVelocity;

    public PlayerCommonStats PlayerStats;
    
    private Vector3 _velocity;
    private float _velocityXSmoothing;

    

    private float _saveDashFrequency;
    private float _counterdashFrequency = 0f;
    private bool _canDash;
    private Controller2D _controller;
    private Vector2 _directionalInput;

    private bool wallSliding;
    private int wallDirX;

    public GameEvent dashEventP1;
    public GameEvent dashEventP2;

    //freeze

    private bool isFrozen;
    public float timeToUnfreeze = 3f;
    private float currentTimeToUnfreeze;


    // Use this for initialization
    void Start()
    {

        currentTimeToUnfreeze = 0f;
        _controller = GetComponent<Controller2D>();

        PlayerStats.gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);

        _saveDashFrequency = PlayerStats.dashFrequency;
        PlayerStats.dashFrequency = -1f;
        _canDash = true;

        _maxJumpVelocity = Mathf.Abs(PlayerStats.gravity) * timeToJumpApex;
        _minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(PlayerStats.gravity) * minJumpHeight);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!isFrozen)
        {
            CalculateVelocity(0);
            HandleWallSliding();

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
                    //Debug.Log("canJump = true");
                    _canDash = true;
                    PlayerStats.dashFrequency = -1;
                    _counterdashFrequency = 0f;
                }
            }


        }
        else
        {

            Debug.Log("counting time");
            currentTimeToUnfreeze += Time.deltaTime;
            if (currentTimeToUnfreeze >= timeToUnfreeze)
            {
                unFreeze();



            }


        }


        
    }
    
    public void freeze()
    {
        isFrozen = true;
        Debug.Log("freeze bitch");

    }

    public void unFreeze()
    {
        Debug.Log("unfreez bitchhhh");
        currentTimeToUnfreeze = 0f;
        isFrozen = false;
        


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

            if (this.gameObject.tag == "Player1")
            {
                if (dashEventP1 != null)
                {
                    dashEventP1.Raise();
                }
            }

            else if (this.gameObject.tag == "Player2")
            {
                if (dashEventP2 != null)
                {
                    dashEventP2.Raise();
                }
            }           
        }
    }


    public void OnJumpInputDown()
    {
        //Debug.Log(wallSliding);
        if (wallSliding)
        {
            if (wallDirX == _directionalInput.x)
            {
                _velocity.x = -wallDirX * wallJumpClimb.x;
                _velocity.y = wallJumpClimb.y;
            }
            else if (_directionalInput.x == 0)
            {
                _velocity.x = -wallDirX * wallJumpOff.x;
                _velocity.y = wallJumpOff.y;
            }
            else
            {
                _velocity.x = -wallDirX * wallLeap.x;
                _velocity.y = wallLeap.y;
            }
  
        }
        
        if (_controller.collisions.grounded)
        {
            _velocity.y = _maxJumpVelocity;

        }
    }

    public void OnJumpInputUp()
    {
        if (_velocity.y > _minJumpVelocity)
        {
            _velocity.y = _minJumpVelocity;
        }
    }

    public Vector3 getVelocityVector()
    {
        return _velocity;

    }

    public void setVelocityX (float amount)
    {
        _velocity.x = amount;

    }
    public void setVelocityY(float amount)
    {
        _velocity.y = amount;
    }
    private void HandleWallSliding()
    {
        wallDirX = (_controller.collisions.right) ? 1 : -1;
        wallSliding = false;

        if ((_controller.collisions.left || _controller.collisions.right ) && !_controller.collisions.grounded && _velocity.y < 0)
        {

            wallSliding = true;

            if (_velocity.y < -wallSlideSpeedMax)
            {
                _velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0f)
            {
                _velocityXSmoothing = 0f;
                _velocity.x = 0f;
                if (_directionalInput.x != wallDirX && _directionalInput.x != 0f)
                {
                    timeToWallUnstick -= Time.deltaTime;


                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }



            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }




        }



    }

    public void CalculateVelocity(float extraMove)
    {

        float targetVelocityX = _directionalInput.x * PlayerStats.moveSpeed  + extraMove*_directionalInput.x;
        _velocity.x = Mathf.SmoothDamp(_velocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerStats.accelerationTimeGrounded);
        _velocity.y += PlayerStats.gravity * Time.deltaTime;
    }
}