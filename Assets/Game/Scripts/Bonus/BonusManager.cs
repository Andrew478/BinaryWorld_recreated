using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    List<GameObject> allBonusesOnLevel = new List<GameObject>();

    [Header("��������� ������ ������� �� ���� ������")]
    public int maxBonusCount = 1; // ������� ����� ����� ���������� �� ���� �� ���� ������
    public Vector2 minMaxTimeInterval = new Vector2(10.0f, 20.0f);

    void Start()
    {
        if (maxBonusCount >= allBonusesOnLevel.Count) maxBonusCount = allBonusesOnLevel.Count - 1;
        if (maxBonusCount < 1) return;
        StartCoroutine(SpawnBonuses());
    }

    public void AddThisBonusInList(GameObject obj)
    {
        allBonusesOnLevel.Add(obj);
    }

    IEnumerator SpawnBonuses()
    {
        Debug.Log("������� �������� ������");
        Debug.Log("����� ������� �� ������: " + allBonusesOnLevel.Count);
        for (int i = 0; i < maxBonusCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(minMaxTimeInterval.x, minMaxTimeInterval.y));
            SpawnBonus();
        }
    }

    void SpawnBonus()
    {
        Debug.Log("����� ���������");
        int bonusIndex = Random.Range(0, allBonusesOnLevel.Count);
        Debug.Log("������ ������ ��� ������: " + bonusIndex);
        if (allBonusesOnLevel[bonusIndex] != null) allBonusesOnLevel[bonusIndex].SetActive(true);
    }
}
