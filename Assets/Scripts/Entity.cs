using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public int facingDir {get; protected set;} = 1; 
    protected bool facingRight = true;

    [Header("Collision Info")]
    public Transform attackCheck;
    public float attackCheckDistance;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask groundMask;

    #region Components
    public Animator anim {get; protected set;}
    public Rigidbody2D rb {get; protected set;}
    public EntityFX fx {get; protected set;}

    #endregion

    protected virtual void Awake(){

    }

    protected virtual void Start(){
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<EntityFX>();
    }

    protected virtual void Update(){

    }

    public virtual void Damage(){
        fx.StartCoroutine("FlashFx");
        Debug.Log($"{gameObject.name} was damaged!");

    }

    #region Collision
    protected virtual void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            groundCheck.position, 
            new Vector3(groundCheck.position.x, 
                groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(
            wallCheck.position, 
            new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, 
                wallCheck.position.y));

        Gizmos.DrawWireSphere(attackCheck.position, attackCheckDistance);
    
    }

    public virtual bool isGroundDetected(){
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);
    }

    public virtual bool isWallDetected(){
        return Physics2D.Raycast(wallCheck.position, Vector2.right*facingDir, wallCheckDistance, groundMask);
    }

    #endregion

    #region Flip
    public virtual void Flip(){
        facingDir = -facingDir;
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);


    }

    public virtual void FlipController(float x){
        if(x > 0 && !facingRight){
            Flip();
        }else if(x < 0 && facingRight){
            Flip();
        }
    }
    #endregion
    
    #region Velocity
    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
        FlipController(vx);
    }

    public void SetVelocity(){
        rb.velocity = new Vector2(0, 0);
    }
    #endregion
}
