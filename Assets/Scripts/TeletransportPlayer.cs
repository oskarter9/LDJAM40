using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportPlayer : MonoBehaviour {

    
    private Controller2D controller;

    public GameObject spawnController;
    private SpawnController spawnContr;

    int size;
	// Use this for initialization
    
    void Awake()
    {
        spawnContr = spawnController.GetComponent<SpawnController>();
        
    }


	void Start () {

        size = spawnContr.getScreenSize();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Debug.Log("tenemos colision");
            controller = collision.gameObject.GetComponent<Controller2D>();
            float value = controller.collisions.faceDirection;

            
            
            collision.gameObject.transform.position += new Vector3((size) * -value , 0, 0);

        }
        


    }
}
