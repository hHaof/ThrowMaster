using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource, backgroundAudio;
    public AudioClip milkHitClip, congratesClip, failClip;
    bool muted;
    public void PlayCongratesSound()
    {
        PlayAudio(congratesClip);
        StopBackgroundMusic();
    }

    public void PlayFailSound()
    {
        PlayAudio(failClip);
        StopBackgroundMusic();
    }

    public void PlayHitSound()
    {
        PlayAudio(milkHitClip);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip, 0.5f);
        }
    }
    private void StopBackgroundMusic()
    {
        backgroundAudio.Stop();
    }

    public void ToggleAudio()
    {
        if (muted)
        {
            muted = true;
            audioSource.mute = true;

        }
        else
        {
            muted = false;
            audioSource.mute = false;

        }
    }
}
