using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    EnemySkeleton enemy;

    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName, EnemySkeleton _enemy) : base(_enemyBase, _enemyStateMachine, _animBoolName)
    {
        this.enemy = _enemy;
        
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.IdleTime;
    }

    public override void Update()
    {
        base.Update();
        // Debug.Log($"timer: {stateTimer}");
        if (stateTimer < 0){
            enemyStateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void Exit(){
        base.Exit();
    }




}
