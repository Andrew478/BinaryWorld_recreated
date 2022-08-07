using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Character : MonoBehaviour, IPlayerStateActions, IDamageble
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

    Vector2 lastDirection; // куда в последний раз игрок шёл

    public GameObject shootVisual;
    
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
        lastDirection = direction;

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


    public void Shoot()
    {
        Debug.Log("Стреляю");
        /*
        LayerMask shootingMask = LayerMask.GetMask("Player", "Enemy", "Object");
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, Vector2.one * 5, 0.0f, lastDirection, 1.5f, shootingMask);
        */
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, Vector2.one, 0.0f, (lastDirection - (Vector2) transform.position), 5.5f);
        StopCoroutine(ShootingEffect()); // завершаем предыдущий выстрел, если игрок не дождался его завершения
        shootVisual.SetActive(false);

        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.name == gameObject.name) return;
            Debug.Log("Попал в объект: " + hit.collider.gameObject.name);
            IDamageble obj = hit.collider.gameObject.GetComponent<IDamageble>();
            if (obj == null) continue;
            Debug.Log("У объекта " + hit.collider.gameObject.name + " найден элемент IDamageble");
            obj.TakeDamage();
        }

        StartCoroutine(ShootingEffect());
        
    }

    IEnumerator ShootingEffect()
    {
        shootVisual.SetActive(true);

        yield return new WaitForSeconds(0.7f);

        shootVisual.SetActive(false);
    }

    public void TakeDamage()
    {
        SetState(NormalState);
    }
}


public enum PlayerName
{
    Gurin = 1,
    Malon = 2
}