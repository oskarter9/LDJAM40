using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerInput : MonoBehaviour

{

    private Player player;

	// Use this for initialization
	void Start () {

        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        player.SetDirectionalInput(directionalInput);
		
       
	}
}
