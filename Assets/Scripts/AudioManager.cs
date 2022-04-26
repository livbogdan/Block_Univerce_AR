using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
               
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.volume = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.mute = sound.mute;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Mute(bool name)
    {
        Sound sound = Array.Find(sounds, s => s.clipBool == name);
        if (name)
            name = false;
        else
            name = true;
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        sound.source.Stop();
        
    }

    public void Pause(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        sound.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        sound.source.UnPause();
    }

}