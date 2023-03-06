using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip[] soundeffects;
    public AudioSource backgroundMusicsource;
    public AudioSource soundEffectsSource;
    // Start is called before the first frame update
    void Start()
    {
        soundEffectsSource = GetComponent<AudioSource>();
    }
    public void PlaySoundEffect(string clipName)
    {
        AudioClip clip = FindClipByName(clipName, soundeffects);
        if (clip != null)
        {
            soundEffectsSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Could not find sound effect clip with the name: " + clipName);
        }
    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusicsource.clip = clip;
        backgroundMusicsource.Play();
    }
    public float GetSoundEffectDuration(string soundEffectName)
    {
        foreach (AudioClip clip in soundeffects)
        {
            if (clip.name == soundEffectName)
            {
                return clip.length;
            }
        }
        Debug.LogWarning($"Sound effect '{soundEffectName}' not found");
        return 0f;

    }
    private AudioClip FindClipByName(string clipName, AudioClip[] clips)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipName) {
                return clip; }
        }
        return null;
    }
  
}
