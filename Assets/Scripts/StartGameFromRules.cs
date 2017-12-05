using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameFromRules : MonoBehaviour {

    public void StartNextScene()
    {
        GameManager.Instance.sceneLoader.LoadSceneInOrder(GameManager.Instance.sceneLoader.nextSceneToLoadIndex);
    }
}
