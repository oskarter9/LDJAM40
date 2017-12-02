using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScenesLoadingQueue")]
public class SceneOrder : ScriptableObject
{
    [System.Serializable]
    public class SceneOrderData
    {
        public int index;
        public string sceneName;
    }

    [SerializeField]
    public List<SceneOrderData> sceneOrderData;
}
