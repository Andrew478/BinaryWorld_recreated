using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TriggerPlayer : MonoBehaviour
{
    [Header("Одноразовый ли триггер")]
    public bool worksSingleTime = true;
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerTrigger player = collision.gameObject.GetComponent<IPlayerTrigger>();
        if (player != null)
        {
            player.TriggerPlayer();
            OnTrigger.Invoke();
            if (worksSingleTime) Destroy(gameObject);
        }
    }
}
