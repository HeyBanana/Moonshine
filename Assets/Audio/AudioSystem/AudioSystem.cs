using System;

public interface IAudioSystem
{
    float SFXVolume { get; set; }
    float MusicVolume { get; set; }
    event Action<float> SFXVolumeChanged;
    event Action<float> MusicVolumeChanged;
    event Action<SoundSettings> OnSFX;
    event Action<SoundSettings> OnMusic;

    void PlaySFX(string key);
    void PlaySFX(SoundSettings settings);
    void PlayMusic(string key);
    void PlayMusic(SoundSettings settings);
}

public class AudioSystem : IAudioSystem
{
    public float SFXVolume { get; set; }
    public float MusicVolume { get; set; }
    public event Action<float> SFXVolumeChanged;
    public event Action<float> MusicVolumeChanged;
    public event Action<SoundSettings> OnSFX;
    public event Action<SoundSettings> OnMusic;

    public void PlaySFX(string key)
    {
        PlaySFX(new SoundSettings(key));
    }

    public void PlaySFX(SoundSettings settings)
    {
        OnSFX?.Invoke(settings);
    }

    public void PlayMusic(string key)
    {
        PlayMusic(new SoundSettings(key));
    }

    public void PlayMusic(SoundSettings settings)
    {
        OnMusic?.Invoke(settings);
    }
}