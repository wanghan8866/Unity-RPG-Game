using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update(){
        base.Update();
        
        if(!Mathf.Approximately(xInput, 0)){
            stateMachine.ChangeState(player.playerMoveState);
        }
    }



    public override void Exit()
    {
        base.Exit();
    }



}
