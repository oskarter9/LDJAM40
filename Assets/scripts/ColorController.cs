using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    public PlayerInput playerInput;
    public PlayerColor playerColor { get; set; }
    public Color red;
    public Color blue;
    public Sprite blueSkull;
    public Sprite redSkull;

    private Material material;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "cuello")
            {
                material = transform.GetChild(i).GetComponent<MeshRenderer>().material;
            }
        } 
    }
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        if (playerInput.PlayerId1 == PlayerInput.PlayerId.Player1)
        {
            playerColor = PlayerColor.BlueColor;
        }

        else
        {
            playerColor = PlayerColor.RedColor;
        }
    }

    public void ChangePlayerColor()
    {
        if (playerColor == PlayerColor.BlueColor)
        {
            playerColor = PlayerColor.RedColor;
            material.color = red;
            GetComponentInChildren<SpriteRenderer>().sprite = redSkull;
        }

        else
        {
            playerColor = PlayerColor.BlueColor;
            material.color = blue;
            GetComponentInChildren<SpriteRenderer>().sprite = blueSkull;
        }
    }

    public enum PlayerColor
    {
        RedColor,BlueColor 
    }

}
