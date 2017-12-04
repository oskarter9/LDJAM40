using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStrip : MonoBehaviour {

    public GameEvent Player1HitByHisColorStrip;
    public GameEvent Player2HitByHisColorStrip;
    public GameEvent StripHasBeenDestroyed;
    private GameObject spawnControllerRef;
    public Transform[] refStrips;

    public const string BlueTag = "BlueStrip";
    public const string RedTag = "RedStrip";


    // Use this for initialization
    void Start () {
        

       

    }
	
	

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

    private void Player2GrowsControl(Collider2D c)
    {
        ColorController colorController = c.gameObject.GetComponent<ColorController>();


        if ((this.gameObject.tag == RedTag && colorController.playerColor == ColorController.PlayerColor.RedColor) ||
            (this.gameObject.tag == BlueTag && colorController.playerColor == ColorController.PlayerColor.BlueColor))
        {
            Player2HitByHisColorStrip.Raise();
        }

        else if ((this.gameObject.tag == RedTag && colorController.playerColor == ColorController.PlayerColor.BlueColor) ||
            (this.gameObject.tag == BlueTag && colorController.playerColor == ColorController.PlayerColor.RedColor))
        {
            Player1HitByHisColorStrip.Raise();
        }
    }

    public void OnTriggerEnter2D (Collider2D collider)
    {

        if (collider.gameObject.tag == "Floor" )
        {
            

            Destroy(this.gameObject);
                  
        }

        else if (collider.gameObject.tag == "Player1")
        {

            //TODO ESCALAR PLAYER 1

            Player1GrowsControl(collider);
            
            //lanza evento a spawncontroller pasandole un parametro con el indice del array refStrips del padre al que esta letra pertenece.
            //desde spawncontroller se va mirando en cada frame cuantos hijos quedan.

            Destroy(this.gameObject);
                    
        }

        else if (collider.gameObject.tag == "Player2")
        {

            //TODO ESCALAR PLAYER 2
            Player2GrowsControl(collider);

            Destroy(this.gameObject);
        }




    }


}
