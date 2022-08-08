using UnityEngine;

public interface IEnemyStateActions
{
    void Move(Vector2 direction);
    void SetState(EnemyState newState);
    void SetAnimation(string triggerName);
    void ResetAnimation(string triggerName);
}
