using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithCharacter1 : MonoBehaviour {

    private GameObject me;
    private Player myPlayer;
    private Player theOtherPlayer;
    public GameObject otherPlayer;
    private Rigidbody2D myRb;
    private Rigidbody2D otherPlayerRb;
    private Controller2D _controller;

    public float bounce = 10f;
	// Use this for initialization
	void Start () {

        _controller = GetComponent<Controller2D>();

        me = this.gameObject;

        myPlayer = GetComponent<Player>();
        theOtherPlayer = otherPlayer.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == otherPlayer)
        {
            Debug.Log("Collision detected");
            Vector3 collisionVelocity = me.GetComponent<Player>().getVelocityVector();

            if (myPlayer.getVelocityVector().x != 0)
            {
      
                theOtherPlayer.setVelocityX(myPlayer.getVelocityVector().x + bounce * _controller.collisions.faceDirection);
                myPlayer.setVelocityX((myPlayer.getVelocityVector().x + bounce) * -_controller.collisions.faceDirection);


            }
            
            
            
            

        }


    }
}
