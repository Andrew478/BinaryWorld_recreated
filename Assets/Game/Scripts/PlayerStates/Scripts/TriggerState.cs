using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerState : MonoBehaviour
{
    public PlayerState newState;

    [Header("Одноразовый ли триггер")]
    public bool worksSingleTime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerStateActions player = collision.gameObject.GetComponent<IPlayerStateActions>();
        if (player != null)
        {
            player.SetState(newState);
        }
        if (worksSingleTime) Destroy(gameObject);
    }
}
