using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    BonusManager bonusManager;
    void Awake()
    {
        bonusManager = GameObject.FindObjectOfType<BonusManager>();
        bonusManager.AddThisBonusInList(gameObject);
        gameObject.SetActive(false);
    }

}
