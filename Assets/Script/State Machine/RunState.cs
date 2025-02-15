using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RunState : State
{
    public AnimationClip anim;

    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {
        float velX = body.linearVelocity.x;

        animator.speed = Helpers.Map(input.maxSpeed, 0, 1, 0, 1.6f, true);

        if (!input.grounded || Mathf.Abs(velX) < 0.1f)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }
}