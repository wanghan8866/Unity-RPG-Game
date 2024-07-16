using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool isBusy { get; private set; }
    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce = 12f;
    public int facingDir {get; private set;} = 1; 
    private bool facingRight = true;


    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundMask;


    [Header("Dash Info")]
    public float dashSpeed; 
    public float dashDuration; 
    public float dashDir {get; private set;}
    [SerializeField] float dashCoolDown;
    float dsahUsageTimer;


    [Header("Attack Detials")]
    public Vector2[] attackMovement = new Vector2[3];



    
    #region Components
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}

    #endregion

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



    private void Awake() {
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

    private void Start() {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Intialize(playerIdleState);
    }



    private void Update() {
        stateMachine.currentState.Update();
        CheckForDashInput();


    }

    public IEnumerator BusyFor(float _s){
        isBusy = true;
        yield return new WaitForSeconds(_s);
        isBusy = false;
    }

    #region Velocity
    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
        FlipController(vx);
    }

    public void SetVelocity(){
        rb.velocity = new Vector2(0, 0);
    }
    #endregion
    
    #region Flip
    void Flip(){
        facingDir = -facingDir;
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);


    }

    public void FlipController(float x){
        if(x > 0 && !facingRight){
            Flip();
        }else if(x < 0 && facingRight){
            Flip();
        }
    }
    #endregion

    #region Collision
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            groundCheck.position, 
            new Vector3(groundCheck.position.x, 
                groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(
            wallCheck.position, 
            new Vector3(wallCheck.position.x + wallCheckDistance, 
                wallCheck.position.y));
    
    }

    public bool isGroundDetected(){
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);
    }

    public bool isWallDetected(){
        return Physics2D.Raycast(wallCheck.position, Vector2.right*facingDir, wallCheckDistance, groundMask);
    }

    #endregion

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
