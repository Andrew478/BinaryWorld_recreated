using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartInJail : MonoBehaviour
{
    public Sprite heartState_inJail;
    public Sprite heartState_free;
    SpriteRenderer spriteRenderer;
    public string playerLayerName = "Player";
    GameManager gameManager;
    public PlayerState newState;
    List<Character> playersList;

    bool player1 = false;
    bool player2 = false;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = heartState_inJail;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        playersList = new List<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            Character c = collision.gameObject.GetComponent<Character>();
            if (c == null) return;

            SetPlayerInOrOutOfZone(c.playerName, true);
            playersList.Add(c);
        }

        if (player1 && player2)
        {
            foreach (Character c in playersList)
            {
                c.SetState(newState);
            }
            spriteRenderer.sprite = heartState_free;
            gameManager.PlayerWin();
            this.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(playerLayerName))
        {
            Character c = collision.gameObject.GetComponent<Character>();
            if (c == null) return;

            SetPlayerInOrOutOfZone(collision.gameObject.GetComponent<Character>().playerName, false);
            playersList.Remove(c);
        }

    }

    void SetPlayerInOrOutOfZone(PlayerName n, bool inside)
    {
        int number = (int) n;

        if (number == 1) player1 = inside;
        else if (number == 2) player2 = inside;
    }
    
}
