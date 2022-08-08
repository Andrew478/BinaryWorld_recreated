using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    static int scoreCount = 0;

    string text_Score = "Score:";
    public TMP_Text scoreText;

    public void UpdateScore(int val)
    {
        val = (val >= 0) ? val : 0;
        scoreCount += val;

        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = text_Score + scoreCount.ToString();
    }
}
