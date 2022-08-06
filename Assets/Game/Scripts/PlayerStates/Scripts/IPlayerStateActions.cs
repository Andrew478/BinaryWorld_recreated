using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStateActions 
{
    bool IsControllable { get; set; } // ���\���� Input ������
    bool IsPlayable { get; set; } // ��� ���������� ����� ����� ��������. true - ��� ���� ����������, false - �����\���� �������� �������. (����������� �������� BinaryWorld)

    void Move(Vector2 direction);
}
