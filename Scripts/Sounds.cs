using UnityEngine.Audio;
using UnityEngine;

//creates a new class called Sound
[System.Serializable]
public class Sound
{
    //name of the sound
    public string name;
    //the audio itself
    public AudioClip clip;
    //creates sliders to adjust the volume and pitch
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    //whether the sound should loop or not
    public bool loop;
    //creates and audio source
    [HideInInspector]
    public AudioSource source;
}
