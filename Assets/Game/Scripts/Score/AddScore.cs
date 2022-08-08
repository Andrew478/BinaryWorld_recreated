using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    ScoreManager manager;
    void Start()
    {
        manager = GameObject.FindObjectOfType<ScoreManager>();
    }

    public void AddScores(int val)
    {
        manager.UpdateScore(val);
    }
}
