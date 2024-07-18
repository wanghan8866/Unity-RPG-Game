using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine enemyStateMachine;
    protected Enemy enemyBase;
    protected bool triggerCalled;
    protected float stateTimer;
    private string animBoolName;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _enemyStateMachine, string _animBoolName){
        this.enemyBase = _enemyBase;
        this.enemyStateMachine = _enemyStateMachine;
        this.animBoolName = _animBoolName;

    }


    public virtual void Enter(){
        triggerCalled = false;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Update(){
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit(){
        enemyBase.anim.SetBool(animBoolName, false);
    }

}
