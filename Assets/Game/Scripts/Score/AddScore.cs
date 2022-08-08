using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    ScoreManager manager;
    public int scoreValue = 200;
    void Start()
    {
        manager = GameObject.FindObjectOfType<ScoreManager>();
    }

    public void AddScores()
    {
        manager.UpdateScore(scoreValue);
    }

    public void SpawnScore()
    {
        manager.SpawnScore((Vector2)transform.position, scoreValue);
    }
}
