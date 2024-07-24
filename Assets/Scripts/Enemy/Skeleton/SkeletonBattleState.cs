using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{       
    EnemySkeleton enemy;
    Transform player;
    int moveDir;

    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName, EnemySkeleton _enemy) : base(_enemyBase, _enemyStateMachine, _animBoolName)
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
        if(enemy.IsPlayerDetected()){
            stateTimer = enemy.battleTime;
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance && CanAttack()){
                enemyStateMachine.ChangeState(enemy.attackState);
                return;
            }
        }else{
            if(stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 15){
                enemyStateMachine.ChangeState(enemy.idleState);
            }
        }
        if(player.position.x > enemy.transform.position.x){
            moveDir = 1;
        }
        else if(player.position.x < enemy.transform.position.x){
            moveDir =-1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);

    }

    public override void Exit(){
        base.Exit();
    }

    bool CanAttack(){
        if(Time.time > enemy.lastTimeAttacked + enemy.attackCooldown){
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }


}
