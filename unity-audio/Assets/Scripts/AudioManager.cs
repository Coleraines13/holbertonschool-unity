using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    private float originalBgmVolume;

    void Start()
    {
        // Initialize references
        bgmSource = GetComponent<AudioSource>();

        // Store original BGM volume
        originalBgmVolume = bgmSource.volume;
    }

    public void MuffleBGM()
    {
        // Muffle BGM by reducing the volume
        bgmSource.volume = originalBgmVolume * 0.3f; // Adjust the value as needed
    }

    public void RestoreBGM()
    {
        // Restore original BGM volume
        bgmSource.volume = originalBgmVolume;
    }
}
