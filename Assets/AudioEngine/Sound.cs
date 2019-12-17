using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string audioClipName;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range(.1f, 3f)]
    public float pitch = 1;

    [Range(0f, 1f)]
    public float spatialBlend;

    public bool Loop;
    

    [HideInInspector]
    public AudioSource source;
}
