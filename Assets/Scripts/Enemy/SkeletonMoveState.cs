using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : EnemyState
{
    EnemySkeleton enemy;

    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName, EnemySkeleton _enemy) : base(_enemyBase, _enemyStateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed*enemy.facingDir, enemy.rb.velocity.y);

        if(enemy.isWallDetected() || !enemy.isGroundDetected()){
            // Debug.Log($"wall: {enemy.isWallDetected()}, ground: {enemy.isGroundDetected()}");
            enemy.Flip();
            enemyStateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void Exit(){
        base.Exit();
    }

}
