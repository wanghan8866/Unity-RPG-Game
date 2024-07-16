using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity();
    }
    public override void Update(){
        base.Update();
        // Debug.Log($"xInput:{xInput}, facing Dir: {player.facingDir}, wall: {player.isWallDetected()}");
        if(Mathf.Approximately(xInput, player.facingDir) && player.isWallDetected()){
            return;
        }
        if(!Mathf.Approximately(xInput, 0) && !player.isBusy){
            stateMachine.ChangeState(player.playerMoveState);
        }
        
    }



    public override void Exit()
    {
        base.Exit();
    }



}
