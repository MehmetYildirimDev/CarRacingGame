using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource, effectSource;

    [SerializeField] private AudioClip GameOverClip;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void PlaySound(object audioClip)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        SaveVolume();
    }

    /// <summary>
    /// effect source
    /// </summary>
    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayGameOverSound()
    {
        effectSource.PlayOneShot(GameOverClip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ChangeEffectVolume(float value)
    {
        effectSource.volume = value;
        PlayerPrefs.SetFloat("effectSource", effectSource.volume);
    }

    public void ChangeMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("musicSource", musicSource.volume);
    }

    public void SaveVolume()
    {
        if (!PlayerPrefs.HasKey("musicSource")) PlayerPrefs.SetFloat("musicSource", 0.5f);
        if (!PlayerPrefs.HasKey("effectSource")) PlayerPrefs.SetFloat("effectSource", 0.5f);

        ChangeMusicVolume(PlayerPrefs.GetFloat("musicSource"));
        ChangeEffectVolume(PlayerPrefs.GetFloat("effectSource"));
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("musicSource", musicSource.volume);
        PlayerPrefs.SetFloat("effectSource", effectSource.volume);
    }

}
