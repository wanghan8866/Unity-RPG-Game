using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float moveSpeed;
    
    #region Components
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}
    #endregion

    #region States
    public PlayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState playerIdleState {get; private set;}
    public PlayerMoveState playerMoveState {get; private set;}
    #endregion



    private void Awake() {
        stateMachine = new PlayerStateMachine();
        playerIdleState = new PlayerIdleState(this, stateMachine, "Idle");
        playerMoveState = new PlayerMoveState(this, stateMachine, "Move");
        

    }

    private void Start() {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Intialize(playerIdleState);
    }



    private void Update() {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
    }
}
