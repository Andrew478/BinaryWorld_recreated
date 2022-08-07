using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerStates/CaughtInWebState")]
public class PlayerStateCaughtInWeb : PlayerState
{
    public override void Init()
    {
        player.IsControllable = false;
        player.SetAnimation(animationTriggerName);
    }

    public override void Exit()
    {
        player.IsControllable = true;
        player.ResetAnimation(animationTriggerName);
    }
}
