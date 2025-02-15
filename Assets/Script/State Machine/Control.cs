using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Control : MonoBehaviour
{
    public AirState airState;
    public IdleState idleState;
    public RunState runState;
    public AttackState attackState;

    State state;

    public Animator animator;


    [Range(0f, 1f)]
    public float groundDecay;
    public float acceleration;
    public float maxSpeed;
    public float attackRange;
    public float attackDamage;

    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public Transform attackPoint;

    public LayerMask groundMask;
    public LayerMask enemyLayers;

    public bool grounded { get; private set; }
    public float xInput { get; private set; }
    public float yInput { get; private set; }

    void Start()
    {
        idleState.Setup(body, animator, this);
        runState.Setup(body, animator, this);
        airState.Setup(body, animator, this);
        attackState.Setup(body, animator, this);
        state = idleState;
    }

    void Update()
    {
        CheckInput();
        HandleJump();

        if (state.isComplete)
        {
            SelectState();
        }

        state.Do();

    }

    void FixedUpdate()
    {
        CheckGround();
        HandleMovement();
        ApplyFriction();

    }

    void SelectState()
    {
        if (grounded)
        {
            if (xInput == 0)
            {
                state = idleState;
            }
            else
            {
                state = runState;
            }
        }
        else
        {
            state = airState;
        }
        state.Enter();
    }

    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

    }

    void HandleMovement()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.linearVelocity.x + increment, -maxSpeed, maxSpeed);
            body.linearVelocity = new Vector2(newSpeed, body.linearVelocity.y);

            FaceInput();

        }
    }
    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, airState.jumpSpeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;

    }

    void checkRange()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("An don" + enemy.name);
        }
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && body.linearVelocity.y <= 0)
        {
            body.linearVelocity *= groundDecay;
        }

    }

    void HandleAttack()
    {
        if (Input.GetKeyDown("f"))
        {
            checkRange();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
