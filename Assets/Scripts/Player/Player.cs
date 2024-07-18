using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    public bool isBusy { get; private set; }
    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce = 12f;






    [Header("Dash Info")]
    public float dashSpeed; 
    public float dashDuration; 
    public float dashDir {get; private set;}
    [SerializeField] float dashCoolDown;
    float dsahUsageTimer;


    [Header("Attack Detials")]
    public Vector2[] attackMovement = new Vector2[3];



    


    #region States
    public PlayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState playerIdleState {get; private set;}
    public PlayerMoveState playerMoveState {get; private set;}
    public PlayerJumpState playerJumpState {get; private set;}
    public PlayerAirState playerAirState {get; private set;}
    public PlayerDashState playerDashState {get; private set;}
    public WallSlideState wallSlideState {get; private set;}
    public WallJumpState wallJumpState {get; private set;}

    public PlayerPrimaryAttack primaryAttack {get; private set;}
    #endregion



    protected override void Awake() {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        playerIdleState = new PlayerIdleState(this, stateMachine, "Idle");
        playerMoveState = new PlayerMoveState(this, stateMachine, "Move");
        playerJumpState = new PlayerJumpState(this, stateMachine, "Jump");
        playerAirState = new PlayerAirState(this, stateMachine, "Jump");
        playerDashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new WallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new WallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "Attack");
        

    }

    protected override void Start() {

        base.Start();
        stateMachine.Intialize(playerIdleState);
    }



    protected override void Update() {
        base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();


    }

    public IEnumerator BusyFor(float _s){
        isBusy = true;
        yield return new WaitForSeconds(_s);
        isBusy = false;
    }


    




    private void CheckForDashInput(){

        dsahUsageTimer -= Time.deltaTime;

        if(isWallDetected()) return;
        if(Input.GetKeyDown(KeyCode.LeftShift) && dsahUsageTimer<0){
            dashDir = Input.GetAxisRaw("Horizontal");
            if(Mathf.Approximately(dashDir, 0)){
                dashDir = facingDir;
            }
            stateMachine.ChangeState(playerDashState);
            dsahUsageTimer = dashCoolDown;
        }
    }

    public void AnimationTrigger(){
        stateMachine.currentState.AnimationFinishTrigger();
    }


}
