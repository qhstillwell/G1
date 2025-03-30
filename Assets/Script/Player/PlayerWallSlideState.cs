using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }
        if(HorizontalMove!=0 && player.facingDir != HorizontalMove)
             stateMachine.ChangeState(player.idleState);
        if (VerticalMove < 0)
            player.rb.linearVelocity = new Vector2 (0,player.rb.linearVelocity.y);
        else
            player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y*.7f);
        if (player.IsGroundDetected())
        
            stateMachine.ChangeState(player.idleState);
    }
}
