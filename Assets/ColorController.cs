using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    public PlayerInput playerInput;
    public PlayerColor playerColor { get; set; }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        if (playerInput.PlayerId1 == PlayerInput.PlayerId.Player1)
        {
            playerColor = PlayerColor.RedColor;
        }

        else
        {
            playerColor = PlayerColor.BlueColor;
        }
    }

    public enum PlayerColor
    {
        RedColor,BlueColor 
    }

}
