using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerInput : MonoBehaviour

{

    private Player player;

	// Use this for initialization
	private void Start () {

        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	private void Update () {

        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.CalculateVelocity(300);
            //Vector2 directionalInput = new Vector2()


        }
		
       
	}
}
