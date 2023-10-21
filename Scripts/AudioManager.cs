using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //creates an array of sounds
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        /*next few lines make sure, there's only one audio manager in a scene preventing
         the sounds to overlap*/
        //if an audio manager doesn't exist in a scene make the current instance it's audio manager
        if (instance == null)
        {
            instance = this;
        } else
        {
            //if an audio manager already exists, destroy the audio manager and return
            Destroy(gameObject);
            return;
        }
        //keep the audio manager when a new scene is loaded
        DontDestroyOnLoad(gameObject);

        //for every sound, add the properties
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //plays the background music
        Play("Theme");
    }

    public void Play(string name)
    {
        //creates a new variable representing the sound 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //if it doesn't exist, show a warning and return
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        //play the sound
        s.source.Play();
    }
}
