using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithCharacter : MonoBehaviour {

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

        if (this.gameObject.tag == "Player1" &&
            collider.gameObject.tag == "Player2" &&
            Mathf.Abs(this.gameObject.GetComponent<Player>().getVelocityVector().x) != 0 &&
            collider.gameObject.GetComponent<Player>().getVelocityVector().x == 0)
        {

            float velX = this.gameObject.GetComponent<Player>().getVelocityVector().x;
            //float velY = this.gameObject.GetComponent<Player>().getVelocityVector().y;

            print("case1");
            this.gameObject.GetComponent<Player>().setVelocityX(velX * -1);

            collider.gameObject.GetComponent<Player>().setVelocityX(velX);



        }


        else if (this.gameObject.tag == "Player2" && 
            collider.gameObject.tag == "Player1" &&
            Mathf.Abs(this.gameObject.GetComponent<Player>().getVelocityVector().x) != 0 &&
            collider.gameObject.GetComponent<Player>().getVelocityVector().x == 0)
        {
            float velX = this.gameObject.GetComponent<Player>().getVelocityVector().x;
            //float velY = this.gameObject.GetComponent<Player>().getVelocityVector().y;
            print("case2");
            this.gameObject.GetComponent<Player>().setVelocityX(velX * -1);

            collider.gameObject.GetComponent<Player>().setVelocityX(velX);



        }

        else if (this.gameObject.tag == "Player1" &&
            collider.gameObject.tag == "Player2" &&
            Mathf.Abs(this.gameObject.GetComponent<Player>().getVelocityVector().x) != 0 &&
            Mathf.Abs(collider.gameObject.GetComponent<Player>().getVelocityVector().x) != 0)
        {

            float velX1 = this.gameObject.GetComponent<Player>().getVelocityVector().x;
            float velX2 =  collider.gameObject.GetComponent<Player>().getVelocityVector().x;
            print("case3");

             
            this.gameObject.GetComponent<Player>().setVelocityX((velX1 * -1) + velX2);

            collider.gameObject.GetComponent<Player>().setVelocityX(velX1 + (velX2 * -1));



        }

       

        if (this.gameObject.tag == "Player1" && 
            collider.gameObject.tag == "Player2")
        {
            float velY1 = this.gameObject.GetComponent<Player>().getVelocityVector().y;
            float velY2 = collider.gameObject.GetComponent<Player>().getVelocityVector().y;

            if (collider.gameObject.GetComponent<Controller2D>().collisions.grounded)
            {

                this.gameObject.GetComponent<Player>().setVelocityY(velY1 * -1);


                


            }

            else if (this.gameObject.GetComponent<Controller2D>().collisions.grounded)
            {


                collider.gameObject.GetComponent<Player>().setVelocityY(velY2 * -1);



            }

            else if (!this.gameObject.GetComponent<Controller2D>().collisions.grounded && !collider.gameObject.GetComponent<Controller2D>().collisions.grounded)
            {

                this.gameObject.GetComponent<Player>().setVelocityY((velY1 * -1) + velY2);
                collider.gameObject.GetComponent<Player>().setVelocityY(velY1 + (velY2 * -1));

            }



        }





    }
}
