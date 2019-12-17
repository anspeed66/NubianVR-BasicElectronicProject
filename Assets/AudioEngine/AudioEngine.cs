using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioEngine : MonoBehaviour
{

    public Sound[] sounds;

    void Start()
    {
        PlayAudio("Theme");
    }
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
            s.source.loop = s.Loop;
        }
    }

    public void PlayAudio(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.audioClipName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound Asset" + name + "not found");
            return;

        }
        s.source.Play();
    }

    public void onHover()
    {
        PlayAudio("ButtonHoverSound");
    }

    public void onSelect()
    {
        PlayAudio("ButtonSelectSound");
    }
}
