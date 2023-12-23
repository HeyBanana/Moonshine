using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickMenuSound;
    [SerializeField] private AudioClip footStepsSound;

    private static SoundManager soundManager;

    public static SoundManager Instance => soundManager;

    private void Awake()
    {
        soundManager = this;
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    public void PlayMenuClick()
    {
        PlaySound(clickMenuSound, Camera.main.transform.position, 0.3f);
    }

    public void PlaySandFootsteps(Vector3 position)
    {
        PlaySound(footStepsSound, position, 0.3f);
    }
}
