using UnityEngine.Audio;
using UnityEngine;

public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public AudioSource source;
}

//FindObjectOfType.<AudioManager>().Play("Nome do som");
//Acha o som com o nome e o executa.