using UnityEngine;
using UnityEngine.Events;

public class TriggerState : MonoBehaviour
{
    public PlayerState newState;
    public UnityEvent OnTrigger; // для прибавления очков

    [Header("Одноразовый ли триггер")]
    public bool worksSingleTime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayerStateActions player = collision.gameObject.GetComponent<IPlayerStateActions>();
        if (player != null)
        {
            player.SetState(newState);
        }
        OnTrigger.Invoke();
        if (worksSingleTime) Destroy(gameObject);
    }

}
