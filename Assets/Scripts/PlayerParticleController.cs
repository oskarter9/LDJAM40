using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour {

    public ParticleSystem dashParticles;
    public GameEvent dashEvent;

    public void PlayDashParticles()
    {
        dashParticles.Play();
    }
}
