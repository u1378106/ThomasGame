using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    private MovementSM _sm;
    private float _verticalInput;

    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(_verticalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //Vector2 vel = _sm.GetComponent<Rigidbody2D>().velocity;
        //vel.x = _horizontalInput * _sm.speed;
        //_sm.GetComponent<Rigidbody2D>().velocity = vel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sm.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10);
        }

    }
}