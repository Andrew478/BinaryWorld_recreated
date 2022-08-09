using UnityEngine;

public interface IPlayerStateActions 
{
    bool IsControllable { get; set; } // ���\���� Input ������
    bool IsPlayable { get; set; } // ��� ���������� ����� ����� ��������. true - ��� ���� ����������, false - �����\���� �������� �������. (����������� �������� BinaryWorld)
    bool IsCaughtInWeb { get; set; }

    GameManager GameM { get; set; }

    void Move(Vector2 direction);
    void SetState(PlayerState newState);
    void SetAnimation(string triggerName);
    void ResetAnimation(string triggerName);
    void Shoot();
    PlayerState GetCurrentState();
}
