using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName, EnemySkeleton _enemy) : base(_enemyBase, _enemyStateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed*enemy.facingDir, rb.velocity.y);

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
