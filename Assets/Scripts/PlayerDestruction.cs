using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestruction : MonoBehaviour {

    public GameEvent onDeathP1;
    public GameEvent onDeathP2;

    public void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag=="Player1")
        {
            Debug.Log("Gana jugador 1");
            if (onDeathP1 != null)
                onDeathP1.Raise();
        }
        else if (c.gameObject.tag == "Player2")
        {
            Debug.Log("Gana jugador 2");
            if (onDeathP2 != null)
                onDeathP2.Raise();
        }
    }
}
