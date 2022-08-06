using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStateActions 
{
    bool IsControllable { get; set; } // вкл\выкл Input игрока
    bool IsPlayable { get; set; } // дл€ управлени€ сразу двум€ игроками. true - идЄт куда указываешь, false - право\лево мен€ютс€ местами. (особенность геймпле€ BinaryWorld)

    void Move(Vector2 direction);
}
