using UnityEngine;

public class PlayerAirStates : PlayerState
{
    public PlayerAirStates(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        if (player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlideStates);
        }

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);

        }
        if (HorizontalMove != 0)
        {
            player.SetVelocity(player.moveSpeed * .8f * HorizontalMove, player.rb.linearVelocity.y);
        }
    }
}
