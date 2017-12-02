using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerCommonStats : ScriptableObject
{
    public float accelerationTimeGrounded;
    public float moveSpeed;
    public float dashForce;
    public float gravity;
    public float dashFrequency;
}
