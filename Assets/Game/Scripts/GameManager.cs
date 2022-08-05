using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    RoundTimer roundTimer;
    MusicManager musicManager;
    UI_AnnouncerWindow announcerWindow;

    void Start()
    {
        roundTimer = gameObject.GetComponent<RoundTimer>();
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        announcerWindow = gameObject.GetComponent<UI_AnnouncerWindow>();
        StartNewGame();
    }

    void Update()
    {
        
    }


    public void RoundTimeEnded()
    {
        announcerWindow.DisplayMessage(true, AnnouncerWindow_AnnounceType.Fail_TimedOut);
        RoundEnded();
    }

    public void PlayerDied()
    {
        
    }
    void RoundEnded()
    {
        roundTimer.ActivateTimer(false);
        musicManager.ChangeMusic(GameMusicStates.GameOverMusic);
    }
    void GameOver()
    {

    }

    void StartNewGame()
    {
        roundTimer.ResetTimer();
        StartRound();
    }
    void StartRound()
    {
        roundTimer.ActivateTimer(true);
        musicManager.ChangeMusic(GameMusicStates.GameMusic);
    }
    void PlayerWin()
    {
        musicManager.ChangeMusic(GameMusicStates.WinMusic);
    }
}
