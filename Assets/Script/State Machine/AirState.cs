using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AirState : State
{
    public AnimationClip anim;

    public float jumpSpeed;

    public override void Enter()
    {
        animator.Play(anim.name);
    }

    public override void Do()
    {
        float time = Helpers.Map(body.linearVelocity.y, jumpSpeed, -jumpSpeed, 0, 1, true);
        animator.Play(anim.name, 0, time);
        animator.speed = 0;

        if (input.grounded)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        
    }
}
