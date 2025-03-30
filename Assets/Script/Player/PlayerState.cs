using UnityEngine;

public class PlayerState
{
    protected float HorizontalMove;
    protected float VerticalMove;
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;
    protected float stateTimer;
    protected bool triggerCalled;
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime; 

        HorizontalMove = Input.GetAxisRaw("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");
        player.anim.SetFloat("yVelocity", player.rb.linearVelocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
