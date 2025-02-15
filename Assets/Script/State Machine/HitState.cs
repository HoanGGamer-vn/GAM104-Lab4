using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HitState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {

    }

    public override void Exit()
    {

    }
}
