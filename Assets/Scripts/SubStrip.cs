using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStrip : MonoBehaviour {


    private GameObject spawnControllerRef;
    Transform[] refStrips;

    // Use this for initialization
    void Start () {

        spawnControllerRef = GameObject.Find("SpawnController");
        refStrips = spawnControllerRef.GetComponent<SpawnController>().GetRefStrip();

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D (Collider2D collider)
    {

        if (collider.gameObject.tag == "Floor" )
        {
            int index = System.Array.IndexOf(refStrips, this.gameObject.transform.parent);

            if(refStrips[index].childCount < 2)
            {
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);
            
            }
            
            Destroy(this.gameObject);
           
            //a ver marc, te comento, este codiguin que pone aqui arriba es una sacada de polla bastante maja. Detecta a que strip corresponde la colision de ese substrip
            //asi que tendremos que cambiar unas cositas. AHORA VUELVO
        }

        if (collider.gameObject.tag == "Player")
        {
            int index = System.Array.IndexOf(refStrips, this.gameObject.transform.parent);

            if (refStrips[index].childCount < 2)
            {
                spawnControllerRef.GetComponent<SpawnController>().GenerateRandomStrip(index);
      
            }

            Destroy(this.gameObject);
        }



    }

    
}
