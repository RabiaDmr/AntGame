using UnityEngine.Audio;
using UnityEngine;
using System;



public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s._source =  gameObject.AddComponent<AudioSource>();
            s._source.clip = s.clip;
            s._source.volume = s.volume;
            s._source.pitch = s.pitch;
            s._source.loop = s.loop;


        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s._source.Play();
    }
}
