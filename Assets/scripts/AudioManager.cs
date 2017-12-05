using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public List<Sound> sounds = new List<Sound>();

	// Use this for initialization
	void Awake () {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}
    
    public void Play(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        s.source.Play();
    }
}
