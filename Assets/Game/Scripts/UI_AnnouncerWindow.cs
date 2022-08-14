using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI_AnnouncerWindow : MonoBehaviour
{
    public TMP_Text text_header;
    public TMP_Text text;
    public GameObject announcerWindow;

    [Space]

    public string text_win = "Now both pinguins have found each other and live happy!";
    public string text_win_header = "Congratulations!";

    [Space]

    public string text_fail_timeout = "Time is out!";
    public string text_fail_caughtInWeb = "You are caught in enemy's web!";
    public string text_fail_header = "Round failed!";

    [Space]

    public string text_gameOver = "Better luck next time!";
    public string text_gameOver_header = "Game over!";

    public void DisplayMessage(bool display, AnnouncerWindow_AnnounceType messageType)
    {
        announcerWindow.SetActive(display);
        if (!display) return;


        switch (messageType)
        {
            case AnnouncerWindow_AnnounceType.PlayerWin:
                ChangeText(text_win_header, text_win);
                break;
            case AnnouncerWindow_AnnounceType.Fail_TimedOut:
                ChangeText(text_fail_header, text_fail_timeout);
                break;
            case AnnouncerWindow_AnnounceType.Fail_caughtInWeb:
                ChangeText(text_fail_header, text_fail_caughtInWeb);
                break;
            case AnnouncerWindow_AnnounceType.GameOver:
                ChangeText(text_gameOver_header, text_gameOver);
                break;
        }
    }

    void ChangeText(string header, string message)
    {
        text_header.text = header;
        text.text = message;
    }
}

public enum AnnouncerWindow_AnnounceType
{
    PlayerWin,
    Fail_TimedOut,
    Fail_caughtInWeb,
    GameOver
}
