 ﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Strip : MonoBehaviour {

	private string blueLetters = "BlueLetters";
    private string redLetters = "RedLetters";

    [SerializeField]
	private Object[] blueObjects;
    [SerializeField]
    private Object[] redObjects;

    private Transform[] children;

    void Awake()
    {
        children = GetComponentsInChildren<Transform>();

        blueObjects = Resources.LoadAll(blueLetters, typeof(GameObject));
        redObjects = Resources.LoadAll(redLetters, typeof(GameObject));
    }

	void Start(){

        
    }

    public Transform[] getChildren()
    {
        return children;


    }

    public void CreateBlueStrip(int size, int numOfStrips, GameObject gO)
    {
        for(int i = 0; i<size; i++)
        {
            Instantiate(blueObjects[0], new Vector3(gO.transform.position.x, gO.transform.position.y + i, gO.transform.position.z), Quaternion.identity, children[numOfStrips+1]);
        }
    }

    
}
