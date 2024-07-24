using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected EnemySkeleton enemy;
    protected Transform player;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName, EnemySkeleton _enemy) : base(_enemyBase, _enemyStateMachine, _animBoolName)
    {
        this.enemy = _enemy;
        
    }
    public override void Enter()
    {
        base.Enter();
        // player = GameObject.Find("Player").transform;
        player = PlayerManager.instance.player.transform;
    }

    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected() || Vector2.Distance(player.position, enemy.transform.position) < enemy.attackDistance){
            enemyStateMachine.ChangeState(enemy.battleState);
        }

    }

    public override void Exit(){
        base.Exit();
    }
}
