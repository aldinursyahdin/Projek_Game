using UnityEngine;  
using System;  
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;

    private bool _paused;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.bypassEffects = s.bypas;
        }
    }
    private void Start()
    {
        Play("Music");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound " + name + "Not Found!");
            return;
        }
        s.source.Play();
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound " + name + "Not Found!");
            return;
        }
        s.source.Pause();
    }
}
