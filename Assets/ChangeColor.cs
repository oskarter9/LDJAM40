using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public int minSecsBetweenInvoke;
    public int maxSecBetweenInvoke;

    public GameEvent preChangeColor;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(CallChangeColor());
    }

    IEnumerator CallChangeColor()
    {
            yield return new WaitForSeconds(1.0f);
            int random = Random.Range(minSecsBetweenInvoke, maxSecBetweenInvoke);
            InvokeRepeating("RaisePreChangeColorEvent", 0.01f,(float)random);
    }

    public void RaisePreChangeColorEvent()
    {
        if (preChangeColor != null)
        {
            preChangeColor.Raise();
        }
    }

}
