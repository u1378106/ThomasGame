using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerStateMachine : StateMachine
{
    [HideInInspector]
    public Idle idleState;

    [HideInInspector]
    public Moving movingState;

    [HideInInspector]
    public Jumping jumpingState;

    public Rigidbody2D rb;

    public float speed = 4f;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}