using UnityEngine;

public interface IPlayerStateActions 
{
    bool IsControllable { get; set; } // вкл\выкл Input игрока
    bool IsPlayable { get; set; } // дл€ управлени€ сразу двум€ игроками. true - идЄт куда указываешь, false - право\лево мен€ютс€ местами. (особенность геймпле€ BinaryWorld)
    bool IsCaughtInWeb { get; set; }

    GameManager GameM { get; set; }

    void Move(Vector2 direction);
    void SetState(PlayerState newState);
    void SetAnimation(string triggerName);
    void ResetAnimation(string triggerName);
    void Shoot();
    PlayerState GetCurrentState();
}
