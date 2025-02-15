using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IdleState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {
        if (!input.grounded || input.xInput != 0)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }
}