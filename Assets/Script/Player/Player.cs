using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Entity
{
    [Header("Attack Details")]
    public float[] attackMovement;
    public float counterAttackDuration = .2f;

    public bool isBusy { get; private set; }   

    [Header("Move Info")]
    public float moveSpeed = 15f;
    public float jumpForce;

    [Header("Dash Info")]
    [SerializeField] private float dashCooldown;
    private float dashTimer;
    public float dashSpeed; 
    public float dashDuration;
    public float dashDir {  get; private set; } 

   
   

 

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public PlayerJumpState jumpStates { get; private set; }
    public PlayerAirStates airStates { get; private set; }  
    public PlayerDashState dashStates { get; private set; }
    public PlayerWallSlideState wallSlideStates { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }

    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerCounterAttackState counterAttack   { get; private set; }
    #endregion
    protected override void Awake()
    {

        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpStates = new PlayerJumpState(this, stateMachine, "Jump");
        airStates = new PlayerAirStates(this, stateMachine, "Jump");
        dashStates = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideStates = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
    }
    protected override void Start()
    {
      base.Start();

        stateMachine.Initialize(idleState);


    }



    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();
       

    }


    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;

    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();


    public void CheckForDashInput()
    {
        if(IsWallDetected())
        {
            return;
        }


        dashTimer -=Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift)&&dashTimer<0)
        {
            dashTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = facingDir;


            stateMachine.ChangeState(dashStates);
        }
        
    }

  
}
