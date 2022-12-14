using UnityEngine;

public abstract class PlayerState : ScriptableObject
{
    public bool IsFinished { get; protected set; }

    [HideInInspector]
    public IPlayerStateActions player;

    public string animationTriggerName;

    public virtual void Init() { }
    public virtual void Run() { }
    public virtual void RunFixedUpdate() { }
    public virtual void Exit() { }
}
