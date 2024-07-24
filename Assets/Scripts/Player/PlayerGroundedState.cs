using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update(){
        base.Update();

        if(Input.GetKeyDown(KeyCode.Q)){
            stateMachine.ChangeState(player.counterAttackState);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            stateMachine.ChangeState(player.primaryAttack);
        }
        if(!player.isGroundDetected()){
            stateMachine.ChangeState(player.playerAirState);
        }

        if(Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected()){
            stateMachine.ChangeState(player.playerJumpState);
        }


        // if(Input.GetKeyDown(KeyCode.LeftShift)){
        //     stateMachine.ChangeState(player.playerDashState);     
        // }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
