using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour
{
    public bool isComplete { get; protected set; }

    protected float startTime;

    public float time => Time.time - startTime;

    protected Rigidbody2D body;
    protected Animator animator;

    protected Control input;

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixeDo() { }
    public virtual void Exit() { }

    public void Setup(Rigidbody2D _body, Animator _animator, Control _control)
    {
        body = _body;
        animator = _animator;
        input = _control;
    }
}
