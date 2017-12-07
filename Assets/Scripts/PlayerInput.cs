using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour

{
	[SerializeField] private PlayerId playerId;

	private Player player;

    [SerializeField]
    private bool JumpEnable;

    public PlayerId PlayerId1
    {
        get
        {
            return playerId;
        }

        set
        {
            playerId = value;
        }
    }

    // Use this for initialization
    private void Start ()
	{
        player = GetComponent<Player>();
	}

	// Update is called once per frame
	private void Update ()
	{
		Vector2 directionalInput;
		
		switch (PlayerId1)
		{
				case PlayerId.Player1:
					directionalInput = new Vector2(Input.GetAxisRaw(AxisNames.player1Axis) + Input.GetAxisRaw("HorizontalMovementKeyboard2"), 0);
                    

                    if (directionalInput.x >1)
                    {
                        directionalInput.x = 1;
                    } 
                    
                    else if (directionalInput.x < -1)
                    {
                    directionalInput.x = -1;
                    }


                    if (Input.GetButtonDown(AxisNames.player1Dash))
                        this.player.Dashing();

                    if (JumpEnable)
                    {
                        if (Input.GetButtonDown(AxisNames.player1Jump))
                        {

                            //Debug.Log("jumping");
                            this.player.OnJumpInputDown();
                    }
                            

                        if (Input.GetButtonUp(AxisNames.player1Jump))
                        {

                            //Debug.Log("jumping");
                            this.player.OnJumpInputUp();
                        }
                            


                    }

                    


                break;
					
				case PlayerId.Player2:


                    
					directionalInput = new Vector2(Input.GetAxisRaw(AxisNames.player2Axis) + Input.GetAxisRaw("HorizontalMovementKeyboard1"), 0);

                    if (directionalInput.x > 1)
                    {
                        directionalInput.x = 1;
                    }

                    else if (directionalInput.x < -1)
                    {
                        directionalInput.x = -1;
                    }


                if (Input.GetButtonDown(AxisNames.player2Dash))
                        this.player.Dashing();

                    if (JumpEnable)
                    {

                        if (Input.GetButtonDown(AxisNames.player2Jump))
                        {

                            Debug.Log("jumping2");
                            this.player.OnJumpInputDown();
                        }


                        if (Input.GetButtonUp(AxisNames.player2Jump))
                        {

                            Debug.Log("jumping2");
                            this.player.OnJumpInputUp();
                        }



                    }


                break;

            default:
					directionalInput = Vector2.zero;
					break;
		}

        player.SetDirectionalInput(directionalInput);
    }
	
	public enum PlayerId
	{
		Player1,Player2
	}

	[System.Serializable]
	public class AxisNames
	{
        public static string player1Jump = "P1_Jump";
        public static string player2Jump = "P2_Jump";
		public static string  player1Axis = "P1_Horizontal";
		public static string  player2Axis = "P2_Horizontal";
        public static string  player1Dash = "P1_Dash";
        public static string  player2Dash = "P2_Dash";
    }
}
