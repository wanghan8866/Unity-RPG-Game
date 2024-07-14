using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update(){
        base.Update();
        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if(Mathf.Approximately(xInput, 0)){
            stateMachine.ChangeState(player.playerIdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
