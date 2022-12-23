using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private Dictionary<string, AudioClip> audioClips;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;
    
    private void Start()
    {
        audioClips = new Dictionary<string, AudioClip>();
        LoadAudioClips();

        musicSource.clip = audioClips["bgm"];
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();

        sfxSource.loop = false;
        sfxSource.volume = sfxVolume;
    }

    private void LoadAudioClips()
    {
        AddAudioClip("bgm", "Audio/bgm");
        AddAudioClip("click", "Audio/click");
        AddAudioClip("equip", "Audio/equip");
        AddAudioClip("chatter", "Audio/chatter");
        AddAudioClip("dino", "Audio/dino");
    }
    
    private void AddAudioClip(string id, string address)
    {
        AudioClip aClip = Resources.Load<AudioClip>(address);
        audioClips.Add(id, aClip);
        aClip.LoadAudioData();
    }
    
    public void PlayAudioClip(string clipName)
    {
        sfxSource.Stop();
        sfxSource.clip = audioClips[clipName];
        sfxSource.Play();
    }

    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }

    public void ResumeBackgroundMusic()
    {
        musicSource.Play();
    }

    public void StopSfx()
    {
        sfxSource.Stop();
    }
}
