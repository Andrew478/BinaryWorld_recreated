using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerStates/CaughtInWebState")]
public class PlayerStateCaughtInWeb : PlayerState
{
    public override void Init()
    {
        player.IsControllable = false;
        player.IsCaughtInWeb = true;
        player.SetAnimation(animationTriggerName);
        player.GameM.CheckForGameOver();
    }

    public override void Exit()
    {
        player.IsControllable = true;
        player.IsCaughtInWeb = false;
        player.ResetAnimation(animationTriggerName);
    }
}
