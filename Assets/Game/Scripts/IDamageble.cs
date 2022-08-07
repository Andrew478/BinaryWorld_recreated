using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Реализующие этот интерфейс могут получать урон от стрельбы игроком
public interface IDamageble
{
    void TakeDamage();
}
