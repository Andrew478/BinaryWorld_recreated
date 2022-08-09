using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    RoundTimer roundTimer;
    MusicManager musicManager;
    UI_AnnouncerWindow announcerWindow;
    ScoreManager scoreManager;

    public IPlayerStateActions player1;
    public IPlayerStateActions player2;

    void Start()
    {
        roundTimer = gameObject.GetComponent<RoundTimer>();
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        announcerWindow = gameObject.GetComponent<UI_AnnouncerWindow>();
        scoreManager = GameManager.FindObjectOfType<ScoreManager>();

        scoreManager.UpdateScoreUI();
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
        RestartGameScene(9);
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
    public void PlayerWin()
    {
        announcerWindow.DisplayMessage(true, AnnouncerWindow_AnnounceType.PlayerWin);
        roundTimer.ActivateTimer(false);
        musicManager.ChangeMusic(GameMusicStates.WinMusic);
        RestartGameScene(12);
    }

    void RestartGameScene(float timeBeforeRestart = 7.0f)
    {
        StartCoroutine(Restart(timeBeforeRestart)); // TODO: Временное решение
    }
    IEnumerator Restart(float timeBeforeRestart)
    {
        yield return new WaitForSeconds(timeBeforeRestart);
        SceneManager.LoadScene(0);
    }
    public void CheckForGameOver()
    {
        if (player1.IsCaughtInWeb & player2.IsCaughtInWeb)
        {
            announcerWindow.DisplayMessage(true, AnnouncerWindow_AnnounceType.Fail_KilledByEnemy_you);
            RoundEnded();
            RestartGameScene();
        }
    }
}
