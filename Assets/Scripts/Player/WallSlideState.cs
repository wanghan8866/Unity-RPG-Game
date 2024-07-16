using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideState : PlayerState
{
    public WallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update(){
        
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space)){
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        if(!Mathf.Approximately(xInput, 0)&&!Mathf.Approximately(xInput,player.facingDir)){
            stateMachine.ChangeState(player.playerIdleState);
        }

        if(yInput < 0){
            player.SetVelocity(0, rb.velocity.y);
        }else{
            player.SetVelocity(0, rb.velocity.y * 0.7f);
        }

        if(player.isGroundDetected()){
            stateMachine.ChangeState(player.playerIdleState);
        }



    }

    public override void Exit()
    {
        base.Exit();
      
    }
}
