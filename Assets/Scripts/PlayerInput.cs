using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour

{
	[SerializeField] private PlayerId playerId;

	private Player player;

	// Use this for initialization
	private void Start ()
	{
        player = GetComponent<Player>();
	}

	// Update is called once per frame
	private void Update ()
	{
		Vector2 directionalInput;
		
		switch (playerId)
		{
				case PlayerId.Player1:
					directionalInput = new Vector2(Input.GetAxisRaw(AxisNames.player1Axis), 0);

                    if (Input.GetButtonDown(AxisNames.player1Dash))
                        this.player.Dashing();

                break;
					
				case PlayerId.Player2:
					directionalInput = new Vector2(Input.GetAxisRaw(AxisNames.player2Axis), 0);

                    if (Input.GetButtonDown(AxisNames.player2Dash))
                        this.player.Dashing();
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
		public static string  player1Axis = "P1_Horizontal";
		public static string  player2Axis = "P2_Horizontal";
        public static string  player1Dash = "P1_Dash";
        public static string  player2Dash = "P2_Dash";
    }
}
