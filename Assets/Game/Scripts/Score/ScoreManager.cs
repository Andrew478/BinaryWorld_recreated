using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ScoreManager : MonoBehaviour
{
    static int scoreCount = 0;

    string text_Score = "Score:";
    public TMP_Text scoreText;
    public GameObject ScoreVisual;
    public float visualScoreLifetime = 2.0f;
    int scoreNumbersInLine = 6;

    public void UpdateScore(int val)
    {
        val = (val >= 0) ? val : 0;
        scoreCount += val;

        UpdateScoreUI();

    }

    public void UpdateScoreUI()
    {
        string s = scoreCount.ToString();
        int zerosNumber = scoreNumbersInLine - s.Length;

        StringBuilder sb = new StringBuilder(scoreNumbersInLine);
        for (int i = 0; i < zerosNumber; i++)
        {
            sb.Append('0');
        }
        sb.Append(s);

        scoreText.text = text_Score + sb.ToString();
    }

    public void SpawnScore(Vector2 point, int scoreVal)
    {
        StartCoroutine(SpawnS(point, ScoreVisual, visualScoreLifetime, scoreVal));
    }

    IEnumerator SpawnS(Vector2 point, GameObject ScoreVis, float waitTime, int scoreVal)
    {
        ScoreVis.SetActive(true);
        ScoreVis.transform.position = (Vector3)point;
        TMP_Text text = ScoreVis.GetComponent<TMP_Text>();
        text.text = scoreVal.ToString();

        yield return new WaitForSeconds(waitTime);
        ScoreVis.SetActive(false);
    }
}
