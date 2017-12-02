using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public SceneLoader sceneLoader;
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        sceneLoader = GetComponent<SceneLoader>();
    }

    private void Start()
    {
        sceneLoader.LoadSceneInOrder(sceneLoader.nextSceneToLoadIndex);
    }

}

