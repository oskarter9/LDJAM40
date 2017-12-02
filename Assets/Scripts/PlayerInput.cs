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
					break;
					
				case PlayerId.Player2:
					directionalInput = new Vector2(Input.GetAxisRaw(AxisNames.player2Axis), 0);
					break;
					
				default:
					directionalInput = Vector2.zero;
					break;
		}

        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.Dashing();
        }
	}
	
	public enum PlayerId
	{
		Player1,Player2
	}

	[System.Serializable]
	public class AxisNames
	{
		public const string  player1Axis = "P1_Horizontal";
		public const string  player2Axis = "P2_Horizontal";
	}
}
