using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameVersion : MonoBehaviour
{
    TMP_Text textVersion;
    void Start()
    {
        textVersion = gameObject.GetComponent<TMP_Text>();
        textVersion.text = "Game\nVersion: " + Application.version.ToString();
    }
}

