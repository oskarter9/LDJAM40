using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour {

    public ParticleSystem dashParticles;
    public ParticleSystem hitParticlesBlue;
    public ParticleSystem hitParticlesRed;
    public ParticleSystem destroyPlayer1;
    public ParticleSystem destroyPlayer2;

    private void Awake()
    {
        StopAllParticles();
    }

    private void StopAllParticles()
    {
        dashParticles.Stop();
        hitParticlesBlue.Stop();
        hitParticlesRed.Stop();
        destroyPlayer1.Stop();
        destroyPlayer2.Stop();
    }

    public void PlayDashParticles()
    {

        dashParticles.gameObject.SetActive(true);
        dashParticles.Play();
  
    }

    public void PlayHitBlueParticles()
    {
        hitParticlesBlue.gameObject.SetActive(true);
        hitParticlesBlue.Play();
    }

    public void PlayHitRedParticles()
    {
        hitParticlesRed.gameObject.SetActive(true);
        hitParticlesRed.Play();
    }

    public void PlayDestroyP1Particles()
    {
        destroyPlayer1.gameObject.SetActive(true);
        Destroy(dashParticles);
        /*Destroy(hitParticlesBlue);
        Destroy(hitParticlesRed);*/
        destroyPlayer1.Play();
        StartCoroutine(WaitForEndOfParticle(1.0f));
    }

    public void PlayDestroyP2Particles()
    {
        destroyPlayer2.gameObject.SetActive(true);
        Destroy(dashParticles);
       /*Destroy(hitParticlesBlue);
        Destroy(hitParticlesRed);*/
        destroyPlayer2.Play();
        StartCoroutine(WaitForEndOfParticle(1.0f));
    }

    IEnumerator WaitForEndOfParticle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
