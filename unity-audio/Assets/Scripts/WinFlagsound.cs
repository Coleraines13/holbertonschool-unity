using UnityEngine;

public class WinFlagsound : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource victorySting;

    private bool hasPlayerTouched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayerTouched)
        {
            hasPlayerTouched = true;
            PlayVictorySting();
            StopBackgroundMusic();
        }
    }

    private void PlayVictorySting()
    {
        victorySting.Play();
    }

    private void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
}