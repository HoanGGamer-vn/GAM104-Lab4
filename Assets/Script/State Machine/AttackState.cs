using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AttackState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {

        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }
}