using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update(){
        base.Update();
        if(player.isGroundDetected()){
            stateMachine.ChangeState(player.playerIdleState);
        }

        if(!Mathf.Approximately(xInput, 0)){
            player.SetVelocity(xInput*0.8f*player.moveSpeed, rb.velocity.y);
        }

        if(player.isWallDetected()){
            stateMachine.ChangeState(player.wallSlideState);
        }
    }

    public override void Exit()
    {
        base.Exit();
      
    }
    
}
