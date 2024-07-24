using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;
    [Header("Move Info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack Info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;


    [Header("Stunned Info")]
    public float stunDuration;
    public Vector2 stunDirection;
    protected bool canBeStunned;
    [SerializeField] protected GameObject counterImage;

    public EnemyStateMachine stateMachine{ get; private set; }

    protected override void Awake() {
        base.Awake();
        stateMachine = new EnemyStateMachine();


    }

    protected override void Update() {
        base.Update();
        stateMachine.currentState.Update();
        

      
    }



    public virtual RaycastHit2D IsPlayerDetected() {
        return Physics2D.Raycast(
            wallCheck.position, 
            Vector2.right*facingDir, 
            attackDistance,
            whatIsPlayer);
    }

    protected override void OnDrawGizmos() {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(
            wallCheck.position, 
            new Vector3(wallCheck.position.x + attackDistance * facingDir, 
                wallCheck.position.y));
    }
    public virtual  void AnimationTrigger(){
        stateMachine.currentState.AnimationFinishTrigger();
    }

    public virtual void OpenCounterAttackWindow(){
        canBeStunned = true;
        counterImage.SetActive(true);
    }
    public virtual void CloseCounterAttackWindow(){
        canBeStunned = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeStunned(){
        if(canBeStunned){
            CloseCounterAttackWindow();
            return true;

        }
        return false;
    }




}
