using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource[] music;
    [SerializeField] private AudioSource[] sfx;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void PlayMainMenuMusic()
    {
        music[2].Play();
        music[0].Stop();
        music[1].Stop();
    }

    public void PlayLevelMusic()
    {
        if (!music[1].isPlaying)
        {
            music[1].Play();
            music[0].Stop();
            music[2].Stop();
        }
    }

    public void PlayBossMusic()
    {
        music[1].Play();
        music[0].Play();
        music[2].Stop();
    }

    public void PlaySFX(int sfxIndex)
    {
        sfx[sfxIndex].Stop();
        sfx[sfxIndex].Play();
    }
    public void PlayAdjustedSFX(int sfxIndex)
    {
        sfx[sfxIndex].pitch = Random.Range(0.8f, 1.2f);
        PlaySFX(sfxIndex);
    }
}
