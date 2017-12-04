using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNextScene : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameManager.Instance.sceneLoader.nextSceneToLoadIndex++;
    }
	

}
