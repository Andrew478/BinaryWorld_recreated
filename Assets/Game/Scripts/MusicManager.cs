using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip GameMusic;
    public AudioClip WinMusic;
    public AudioClip GameOverMusic;
    AudioSource audioSource;

    

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0.3f;

        ChangeMusic(GameMusicStates.GameMusic);
    }

    public void ChangeMusic(GameMusicStates newState)
    {
        switch (newState)
        {
            case GameMusicStates.GameMusic:
                audioSource.clip = GameMusic;
                break;
            case GameMusicStates.WinMusic:
                audioSource.clip = WinMusic;
                break;
            case GameMusicStates.GameOverMusic:
                audioSource.clip = GameOverMusic;
                break;
        }

        audioSource.Play();
    }
}

public enum GameMusicStates
{
    GameMusic,
    WinMusic,
    GameOverMusic
}
