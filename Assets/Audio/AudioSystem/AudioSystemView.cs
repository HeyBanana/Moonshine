using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class AudioSystemView : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private AudioPlayer _sfxPrefab;
    [SerializeField] private AudioPlayer _musicPrefab;

    [SerializeField] private AudioClip[] _sfx;
    [SerializeField] private AudioClip[] _music;

    private ObjectPool<AudioPlayer> _sfxPool;
    private ObjectPool<AudioPlayer> _musicPool;
    private AudioPlayer _currentMusic;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _sfxPool = new ObjectPool<AudioPlayer>(_sfxPrefab, transform);
        _musicPool = new ObjectPool<AudioPlayer>(_musicPrefab, transform);

        var audioSystem = Context.Instance.AudioSystem;

        audioSystem.OnMusic += OnPlayMusic;
        audioSystem.OnSFX += OnPlaySFX;
    }

    [ContextMenu("PlaySFX")]
    public void PlaySFX()
    {
        OnPlaySFX(new SoundSettings(key));
    }

    public void OnPlaySFX(SoundSettings settings)
    {
        var clip = _sfx.FirstOrDefault(s => s.name == settings.key);

        if (clip == null)
        {
            Debug.LogAssertion($"There is no clip with name {settings.key}");
            return;
        }

        var audioPlayer = _sfxPool.GetObject();
        audioPlayer.Set(settings, clip);
    }

    public void OnPlayMusic(SoundSettings settings)
    {
        var clip = _music.FirstOrDefault(s => s.name == settings.key);
        if (clip == null)
        {
            Debug.LogAssertion($"There is no clip with name {settings.key}");
            return;
        }

        _currentMusic?.Fade(false, 1f);
        _currentMusic = _musicPool.GetObject();
        _currentMusic.Set(settings, clip);
        _currentMusic.Fade(true, 1f);
    }
}