﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPowerupPlayer : MonoBehaviour {


    private SpawnController spawnController;
	// Use this for initialization
	void Start () {
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

            spawnController.PowerupIsGrounded();


        }

        if (collision.gameObject.tag == "Player1" ||collision.gameObject.tag == "Player2")
        {
            Destroy(this.gameObject);
            Debug.Log("destruido");
            spawnController.PowerupFreezeIsDestroyed();


        }
    }
}
