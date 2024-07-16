using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    int combatCounter;
    float lastTimeAttack;
    float comboWindow = 2;

    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        if(Time.time - lastTimeAttack < comboWindow){
            combatCounter %= 3;
        }else{
            combatCounter = 0;
        }

        Debug.Log($"Attack {combatCounter}");
        player.anim.SetInteger("CombatCounter", combatCounter);

        float attackDirection = player.facingDir;
        if(!Mathf.Approximately(xInput, 0)){
            attackDirection = xInput;
        }

        player.SetVelocity(
            player.attackMovement[combatCounter].x*attackDirection, 
            player.attackMovement[combatCounter].y);
        stateTimer = 0.1f;
        
    }
    public override void Update(){
        base.Update();

        if(stateTimer < 0){
            player.SetVelocity();
        }

        if(triggerCalled){
            stateMachine.ChangeState(player.playerIdleState);
        }

    }

    public override void Exit()
    {
        player.StartCoroutine("BusyFor", 0.2f );
        base.Exit();
        combatCounter ++ ;
        lastTimeAttack = Time.time;
    }

}
