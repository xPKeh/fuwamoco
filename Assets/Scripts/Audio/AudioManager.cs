using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource, sfxSource;

    [Header("---------- Sounds ----------")]
    //estaba probando pasandole una lista de un script serializable, y pasar nombres en vez de toda la instancia con el audioclip.
    //public Sound[] musicSounds, sfxSounds;
    public AudioClip background;
    public AudioClip alternativeBackground;
    public AudioClip jump;
    public AudioClip pickUp;
    public AudioClip playerInteractive;
    public AudioClip plantBurn;
    public AudioClip portalActivate;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sound)
    {
        //va con la array comentada.
        //Sound s = Array(sfxSounds, x => x.name == name);

        sfxSource.PlayOneShot(sound);
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
