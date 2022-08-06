using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStates/NormalState")]
public class PlayerStateNormal : PlayerState
{
    Vector2 direction;

    public override void RunFixedUpdate()
    {
        if (player.IsControllable)
        {
            if (Input.GetKey(KeyCode.W)) player.Move(Vector2.up);
            else if (Input.GetKey(KeyCode.S)) player.Move(Vector2.down);
            else if (Input.GetKey(KeyCode.A)) player.Move(player.IsPlayable ? Vector2.left : -Vector2.left);
            else if (Input.GetKey(KeyCode.D)) player.Move(player.IsPlayable ? Vector2.right : -Vector2.right);
        }
    }
}
