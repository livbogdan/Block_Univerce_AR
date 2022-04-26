using UnityEngine.Audio;
using UnityEngine;



//Connected to AudioManager.cs
[System.Serializable]
public class Sound
{
    //Name of clip
    public string name;
    public bool clipBool;

    //Audio clip
    public AudioClip clip;

    //Volume slider
    [Range(0f, 1f)]
    public float volume;
    //Pitch slider
    [Range(.1f, 3f)]
    public float pitch;
    //Loop sound
    public bool loop;
    //Mute
    public bool mute;

    //Audio Source
    [HideInInspector]
    public AudioSource source;
}
