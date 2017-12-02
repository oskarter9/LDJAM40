using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputJ2 : MonoBehaviour {
    
    public float speedH;

	
    // Update is called once per frame
    void Update ()
    {
        float h = Input.GetAxisRaw("Horizontal2");


        float delta = h * speedH * Time.deltaTime;

		
        transform.position = new Vector3(transform.position.x+ delta,transform.position.y,transform.position.z);
    }
}
