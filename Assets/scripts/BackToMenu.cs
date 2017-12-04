using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour {

    public int index;

    public void Back()
    {
        GameManager.Instance.sceneLoader.nextSceneToLoadIndex = index;
        GameManager.Instance.sceneLoader.LoadSceneInOrder(GameManager.Instance.sceneLoader.nextSceneToLoadIndex);
    }
}
