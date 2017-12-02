using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int nScenesLoaded = 0;
    private int currentSceneIndex = 0;

    public SceneOrder sceneOrder;    
    public int nextSceneToLoadIndex;

    private void Awake()
    {
        nextSceneToLoadIndex = sceneOrder.sceneOrderData[0].index;
    }

    public void LoadSceneInOrder(int index)
    {
        SceneManager.LoadScene(sceneOrder.sceneOrderData[index - 1].sceneName,LoadSceneMode.Single);
        nScenesLoaded++;
        currentSceneIndex ++;
        nextSceneToLoadIndex++;
    }

}
