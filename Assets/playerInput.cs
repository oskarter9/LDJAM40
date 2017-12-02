using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerInput : MonoBehaviour
{

	public float speedH;
	
	// Update is called once per frame
	void Update ()
	{
		float delta = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speedH;
		transform.position = new Vector3(transform.position.x+delta,transform.position.y,transform.position.z);
	}
}
