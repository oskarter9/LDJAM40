using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStrip : MonoBehaviour {

    public GameEvent pickUpEvent;
    private GameObject spawnControllerRef;
    public Transform[] refStrips;

    private bool enableTimer;
    public float maxTimeToDestroyLetter = 0.05f;
    private float currentTimeToDestroyLetter;

    // Use this for initialization
    void Start () {

        currentTimeToDestroyLetter = 0f;
        spawnControllerRef = GameObject.Find("SpawnController");
        refStrips = spawnControllerRef.GetComponent<SpawnController>().GetRefStrip();

    }
	
	// Update is called once per frame
	void Update () {
        if (enableTimer)
        {
            currentTimeToDestroyLetter += Time.deltaTime;

            if (currentTimeToDestroyLetter >= maxTimeToDestroyLetter)
            {
                enableTimer = false;
                Destroy(this.gameObject);


            }
            


        }
    }

    public void OnTriggerEnter2D (Collider2D collider)
    {

        if (collider.gameObject.tag == "Floor" )
        {
            refStrips = spawnControllerRef.GetComponent<SpawnController>().GetRefStrip();
            int index = System.Array.IndexOf(refStrips, this.gameObject.transform.parent);

            if(refStrips[index].childCount <4)
            {
                enableTimer = true;
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);
                
      
            
<<<<<<< HEAD
            }
            else
            {
                Destroy(this.gameObject);
            }
           
            
=======
            }          
            Destroy(this.gameObject);
>>>>>>> c2ebf98c73dc7161e87dafa2dc0abe32f5e15650
           
       
        }

        else if (collider.gameObject.tag == "Player")
        {
            refStrips = spawnControllerRef.GetComponent<SpawnController>().GetRefStrip();
            int index = System.Array.IndexOf(refStrips, this.gameObject.transform.parent);

            if (refStrips[index].childCount <4)
            {
                enableTimer = true;
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);
<<<<<<< HEAD
                

            }
            else
            {
                Destroy(this.gameObject);
            }
=======
            }
            Destroy(this.gameObject);
>>>>>>> c2ebf98c73dc7161e87dafa2dc0abe32f5e15650
        }



    }

    
}
