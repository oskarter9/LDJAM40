using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunDown : MonoBehaviour {

    public float numMinutes;
    public float finalSunPos = -8.4f;
    private float downRatio;
	// Use this for initialization
	void Start () {

        downRatio = finalSunPos / (numMinutes * 60);

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, transform.position.y + downRatio * Time.deltaTime, transform.position.z);

        if (transform.position.y <= finalSunPos)
        {
            downRatio = 0;
            Debug.Log("ACABADO!");
        }
	}
}
