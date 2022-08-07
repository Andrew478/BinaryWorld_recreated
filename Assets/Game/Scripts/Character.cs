using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Character : MonoBehaviour, IPlayerStateActions
{
    public PlayerName playerName;
    
    Rigidbody2D rb;
    Animator animator;

    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;

    public bool IsControllable { get { return isControllable; } set { isControllable = value; } }
    public bool isControllable = true;
    public bool IsPlayable { get { return isPlayable; } set { isPlayable = value; } }
    public bool isPlayable = true;

    public PlayerState StartState;
    public PlayerState CurrentState; // public для Debug

    public PlayerState NormalState;
    public PlayerState InvincibleState;
    public PlayerState CaughtInWebState;
    public PlayerState RoundWinState;

    GameManager gameManager;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if ((int)playerName == 1) gameManager.player1 = this;
        else if ((int)playerName == 2) gameManager.player2 = this;

        SetState(StartState);
    }

    void FixedUpdate()
    {
        if (!CurrentState.IsFinished) CurrentState.RunFixedUpdate();
    }
    void Update()
    {
        if (!CurrentState.IsFinished) CurrentState.Run(); // смена состояния происходит путём триггеринга извне
    }


    public void SetState(PlayerState newState)
    {
        if (CurrentState != null) CurrentState.Exit();
        CurrentState = Instantiate(newState);
        CurrentState.player = this;
        CurrentState.Init();
    }
    public void Move(Vector2 direction)
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(position + translation);
    }
    public void SetAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    public void ResetAnimation(string triggerName)
    {
        animator.ResetTrigger(triggerName);
    }
}


public enum PlayerName
{
    Gurin = 1,
    Malon = 2
}