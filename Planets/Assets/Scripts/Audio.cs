using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip mainTheme;

    [SerializeField] private AudioClip button;
    [SerializeField] private AudioClip explosion;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMainTheme()
    {
        PlaySound(mainTheme);
    }

    public void PlayExplosionSound()
    {
        PlaySound(explosion);
    }

    public void PlayButtonClickSound()
    {
        PlaySound(button);
    }

    public void PlaySound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
