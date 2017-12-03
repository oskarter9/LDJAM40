using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyTools.SoundManager;

public class SoundController : MonoBehaviour {

    public AudioClip hitSound;

    void Start()
    {
        SoundManager.PlaySound(hitSound);
    }
}
