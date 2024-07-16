using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : PlayerState
{
    public WallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.5f;
        player.SetVelocity(5 * - player.facingDir, player.jumpForce);

    }

    public override void Update(){
        base.Update();
        if(stateTimer < 0){
            stateMachine.ChangeState(player.playerAirState);
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
