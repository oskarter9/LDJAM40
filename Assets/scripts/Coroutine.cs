using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour {

    Canvas canvas;
    public GameEvent realChangeColor;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
    public void startWait()
    {
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
        canvas.enabled = false;
        realChangeColor.Raise();
    }
}
