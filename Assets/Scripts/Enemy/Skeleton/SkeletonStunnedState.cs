using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    EnemySkeleton enemy;
    public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName, EnemySkeleton _enemy) : base(_enemyBase, _enemyStateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(-enemy.facingDir*enemy.stunDirection.x, enemy.stunDirection.y);
        stateTimer = enemy.stunDuration;
        enemy.fx.InvokeRepeating("RedColourBlink", 0, .1f);
   
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0){
            enemyStateMachine.ChangeState(enemy.idleState);
        }

    }

    public override void Exit(){
        base.Exit();
        enemy.fx.Invoke("CancelRedBlink", 0);
    }
}