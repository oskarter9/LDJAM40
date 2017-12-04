using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStrip : MonoBehaviour {

<<<<<<< HEAD
    public GameEvent pickUpEvent;
    private GameObject spawnControllerRef;
    public Transform[] refStrips;

    private bool enableTimer;
    public float maxTimeToDestroyLetter = 0.05f;
    private float currentTimeToDestroyLetter;
=======
    public GameEvent Player1HitByHisColorStrip;
    public GameEvent Player2HitByHisColorStrip;

    public GameEvent StripHitP1Red;
    public GameEvent StripHitP1Blue;
    public GameEvent StripHitP2Red;
    public GameEvent StripHitP2Blue;


    private GameObject spawnControllerRef;
    public Transform[] refStrips;

    public const string BlueTag = "BlueStrip";
    public const string RedTag = "RedStrip";

>>>>>>> ricky-save

    // Use this for initialization
    void Start () {
        

       

    }
	
<<<<<<< HEAD
	// Update is called once per frame
	void Update () {
        if (enableTimer)
        {
            currentTimeToDestroyLetter += Time.deltaTime;

            if (currentTimeToDestroyLetter >= maxTimeToDestroyLetter)
            {
                enableTimer = false;
                Destroy(this.gameObject);
=======
	

    private void Player1GrowsControl(Collider2D c)
    {
        ColorController colorController = c.gameObject.GetComponent<ColorController>();


        if ((this.gameObject.tag == RedTag && colorController.playerColor == ColorController.PlayerColor.RedColor) ||
            (this.gameObject.tag == BlueTag && colorController.playerColor == ColorController.PlayerColor.BlueColor))
        {
            Player1HitByHisColorStrip.Raise();
        }

        else if ((this.gameObject.tag == RedTag && colorController.playerColor == ColorController.PlayerColor.BlueColor) ||
            (this.gameObject.tag == BlueTag && colorController.playerColor == ColorController.PlayerColor.RedColor))
        {
            Player2HitByHisColorStrip.Raise();
        }
    }
>>>>>>> ricky-save


            }
            


        }
    }

    public void OnTriggerEnter2D (Collider2D collider)
    {

        if (collider.gameObject.tag == "Floor")
        {

<<<<<<< HEAD
            if(refStrips[index].childCount <4)
            {
                enableTimer = true;
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);
                
      
            
            }
            else
            {
                Destroy(this.gameObject);
            }        
           
       
        }
=======
            Destroy(this.gameObject);
>>>>>>> ricky-save

        }
        else if (collider.gameObject.tag == "Player1")
        {
            if (this.gameObject.tag == RedTag)
            {
                if (StripHitP1Red != null)
                    StripHitP1Red.Raise();
            }

<<<<<<< HEAD
            //SI ES UNA LETRA AZUL LANZAR EVENTO ENGORDAR(PLAYER 2)
            //SI ES UNA LETRA ROJA LANZAR EVENTO ENGORDAR(THIS PLAYER)

            refStrips = spawnControllerRef.GetComponent<SpawnController>().GetRefStrip();
            int index = System.Array.IndexOf(refStrips, this.gameObject.transform.parent);

            if (refStrips[index].childCount <4)
            {
                enableTimer = true;
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);                

            }
            else
            {
                Destroy(this.gameObject);
            }
            
=======
            if (this.gameObject.tag == BlueTag)
            {
                if (StripHitP1Blue != null)
                    StripHitP1Blue.Raise();
            }

            Player1GrowsControl(collider);

            Destroy(this.gameObject);


>>>>>>> ricky-save
        }
        else if (collider.gameObject.tag == "Player2")
        {
<<<<<<< HEAD


            //SI ES UNA LETRA ROJA LANZAR EVENTO ENGORDAR(PLAYER 1)
            //SI ES UNA LETRA AZUL LANZAR EVENTO ENGORDAR(THIS PLAYER)

            refStrips = spawnControllerRef.GetComponent<SpawnController>().GetRefStrip();
            int index = System.Array.IndexOf(refStrips, this.gameObject.transform.parent);

            if (refStrips[index].childCount < 4)
            {
                enableTimer = true;
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);

=======
            if (this.gameObject.tag == RedTag)
            {
                if (StripHitP2Red != null)
                    StripHitP2Red.Raise();
>>>>>>> ricky-save
            }

            if (this.gameObject.tag == BlueTag)
            {
                if (StripHitP2Blue != null)
                    StripHitP2Blue.Raise();
            }

<<<<<<< HEAD


        }



    }
=======
            Player2GrowsControl(collider);


            Destroy(this.gameObject);
           
        }

            


        
    }

   
>>>>>>> ricky-save

    
}
