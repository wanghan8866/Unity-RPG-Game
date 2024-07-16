using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.dashDuration;
    }
    public override void Update(){
        base.Update();
        if(!player.isGroundDetected() && player.isWallDetected()){
            stateMachine.ChangeState(player.wallSlideState);
            return;
        }
        
        player.SetVelocity(player.dashSpeed * player.dashDir,
         (player.isGroundDetected())?rb.velocity.y:0);
        // Debug.Log($"Dashing {stateTimer}");

        if(stateTimer < 0){
            stateMachine.ChangeState(player.playerIdleState);
        }
    }



    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rb.velocity.y);
   
    }

}
