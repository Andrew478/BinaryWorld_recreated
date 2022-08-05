using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    public float RoundTimeStart = 99.0f;
    float roundTime;
    bool countTime = true;


    GameManager gameManager;
    public TMP_Text roundText;

    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        ResetTimer();
        ActivateTimer(true);
    }

    void Update()
    {
        CountTime();
    }

    public void ActivateTimer(bool start)
    {
        countTime = start ? true : false;
    }

    public void ResetTimer()
    {
        roundTime = RoundTimeStart;
    }

    void CountTime()
    {
        if (!countTime) return;

        roundTime -= Time.deltaTime;
        DisplayTime(roundText, roundTime);

        if (roundTime <= 0)
        {
            ActivateTimer(false);
            ResetTimer();
            gameManager.RoundTimeEnded();
        }
    }

    void DisplayTime(TMP_Text text, float value, string textBeforeValue = "Time:")
    {
        roundText.text = textBeforeValue + Mathf.RoundToInt(roundTime).ToString();
    }
}
