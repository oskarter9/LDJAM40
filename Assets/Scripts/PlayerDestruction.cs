using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestruction : MonoBehaviour {

    public GameEvent onDeathP1;
    public GameEvent onDeathP2;

    private PlayerInput refPlayerInput;


    public void OnTriggerEnter2D(Collider2D c)
    {
        refPlayerInput = c.gameObject.GetComponent<PlayerInput>();

        if(c.gameObject.tag=="Player1")
        {
            if (onDeathP1 != null)
            {
                c.enabled = false;
                refPlayerInput.enabled = false;
                onDeathP1.Raise();
                StartCoroutine(WaitForEndOfGame1(2.0f));

            } 
        }
        else if (c.gameObject.tag == "Player2")
        {
            if (onDeathP2 != null)
            {
                c.enabled = false;
                refPlayerInput.enabled = false;
                onDeathP2.Raise();
                StartCoroutine(WaitForEndOfGame2(1.0f));

            }

        }
        

    }

    IEnumerator WaitForEndOfGame1(float duration)
    {
        yield return new WaitForSeconds(duration);
        GameManager.Instance.sceneLoader.LoadSceneInOrder(GameManager.Instance.sceneLoader.nextSceneToLoadIndex + 1);
    }


    IEnumerator WaitForEndOfGame2(float duration)
    {
        yield return new WaitForSeconds(duration);
        GameManager.Instance.sceneLoader.LoadSceneInOrder(GameManager.Instance.sceneLoader.nextSceneToLoadIndex);
    }
}
