using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static AudioManager instance { get; private set; }

    [SerializeField]
    private List<AudioHolder> audioClipsList = new List<AudioHolder>();

    private Dictionary<SoundsFX, AudioClip> audioClipsDictionary = new Dictionary<SoundsFX, AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = Camera.main.GetComponent<AudioSource>();

        foreach (AudioHolder audio in audioClipsList)
        {
            if (!audioClipsDictionary.ContainsValue(audio.audioClip))
                audioClipsDictionary.Add(audio.audiokey, audio.audioClip);
        }
    }

    public void PlayClip(SoundsFX audioClipKey)
    {
        if (audioClipsDictionary.ContainsKey(audioClipKey))
        {
            audioSource.PlayOneShot(audioClipsDictionary[audioClipKey]);
        }
    }
}

[System.Serializable]
public class AudioHolder
{
    public SoundsFX audiokey;
    public AudioClip audioClip;

    public AudioHolder(SoundsFX audiokey, AudioClip audioClip)
    {
        this.audiokey = audiokey;
        this.audioClip = audioClip;
    }
}

public enum SoundsFX
{
    SFX_Coin,
    SFX_Win,
    SFX_Lose,
    SFX_Acid,
    SFX_EnemiesAppering,
    Music_Ingame,
    Music_Menu
}