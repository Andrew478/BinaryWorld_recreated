using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerState : MonoBehaviour
{
    public PlayerState newState;
    public CollisionType collisonType = CollisionType.Trigger;
    bool isCollisionEnabled = true;
    float collisionCooldown = 1.0f; // Чтобы избежать повторного вызова метода коллизии за короткий промежуток времени

    public UnityEvent OnTrigger; // для прибавления очков

    [Header("Одноразовый ли триггер")]
    public bool worksSingleTime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisonType == CollisionType.Trigger)
        {
            IPlayerStateActions player = collision.gameObject.GetComponent<IPlayerStateActions>();
            if (player != null)
            {
                player.SetState(newState);
                OnTrigger.Invoke();
                if (worksSingleTime) Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isCollisionEnabled && collisonType == CollisionType.Collider)
        {
            if(!worksSingleTime) StartCoroutine(CollisionCooldown(collisionCooldown));
            IPlayerStateActions player = collision.gameObject.GetComponent<IPlayerStateActions>();
            if (player != null)
            {
                player.SetState(newState);
                OnTrigger.Invoke();
                if (worksSingleTime) Destroy(gameObject);
            }
        }
    }

    IEnumerator CollisionCooldown(float cooldownTime)
    {
        isCollisionEnabled = false;
        yield return new WaitForSeconds(cooldownTime);
        isCollisionEnabled = true;
    }
}

public enum CollisionType
{
    Collider,
    Trigger
}
