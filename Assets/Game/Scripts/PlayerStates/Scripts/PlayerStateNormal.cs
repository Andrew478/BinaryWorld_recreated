using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStates/NormalState")]
public class PlayerStateNormal : PlayerState
{
    Vector2 direction;

    public override void Init()
    {
        player.IsControllable = true;
        player.SetAnimation(animationTriggerName);
    }
    public override void RunFixedUpdate()
    {
        if (player.IsControllable)
        {
            if (Input.GetKey(KeyCode.W)) player.Move(Vector2.up);
            else if (Input.GetKey(KeyCode.S)) player.Move(Vector2.down);
            else if (Input.GetKey(KeyCode.A)) player.Move(player.IsPlayable ? Vector2.left : -Vector2.left);
            else if (Input.GetKey(KeyCode.D)) player.Move(player.IsPlayable ? Vector2.right : -Vector2.right);
        }

        //if (Input.GetKeyDown(KeyCode.Space)) player.Shoot();
    }
    public override void Run()
    {
        if (Input.GetKeyDown(KeyCode.Space)) player.Shoot(); // TODO: перенести в FixedUpdate?
    }
    public override void Exit()
    {
        player.ResetAnimation(animationTriggerName);
    }
}
